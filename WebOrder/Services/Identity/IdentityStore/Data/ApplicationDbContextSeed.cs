using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using IdentityStore.API.Extensions;
using IdentityStore.API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IdentityStore.API.Data
{
    public class ApplicationDbContextSeed
    {
        private readonly IPasswordHasher<ApplicationStore> _passwordHasher = new PasswordHasher<ApplicationStore>();
        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env,
            ILogger<ApplicationDbContextSeed> logger, IOptions<AppSettings> settings, int? retry = 0)
        {
            int retryForAvaiability = retry.Value;

            try
            {
                var useCustomizationData = settings.Value.UseCustomizationData;
                var contentRootPath = env.ContentRootPath;
                var webroot = env.WebRootPath;

                if (!context.Users.Any())
                {
                    context.Users.AddRange(useCustomizationData
                        ? GetUsersFromFile(contentRootPath, logger)
                        : GetDefaultUser());

                    await context.SaveChangesAsync();
                }

                if (useCustomizationData)
                {
                    GetPreconfiguredImages(contentRootPath, webroot, logger);
                }
            }
            catch (Exception ex)
            {
                if (retryForAvaiability < 10)
                {
                    retryForAvaiability++;

                    logger.LogError(ex, "EXCEPTION ERROR while migrating {DbContextName}", nameof(ApplicationDbContext));

                    await SeedAsync(context, env, logger, settings, retryForAvaiability);
                }
            }
        }

        public IEnumerable<ApplicationStore> GetUsersFromFile(string contentRootPath, ILogger logger)
        {
            string csvFileUsers = Path.Combine(contentRootPath, "Setup", "User.csv");
            if (!File.Exists(csvFileUsers))
            {
                return GetDefaultUser();
            }
            string[] csvheaders;
            try
            {
                string[] requiredHeaders = {
                    "email","name", "phonenumber",
                    "username","palace",
                    "normalizedemail", "normalizedusername", "password"
            };
                csvheaders = GetHeaders(requiredHeaders, csvFileUsers);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "EXCEPTION ERROR: {Message}", ex.Message);

                return GetDefaultUser();
            }
            List<ApplicationStore> users = File.ReadAllLines(csvFileUsers)
                            .Skip(1) // skip header column
                            .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                            .SelectTry(column => CreateApplicationUser(column, csvheaders))
                            .OnCaughtException(ex => { logger.LogError(ex, "EXCEPTION ERROR: {Message}", ex.Message); return null; })
                            .Where(x => x != null)
                            .ToList();

            return users;
        }

        private ApplicationStore CreateApplicationUser(string[] column, string[] headers)
        {
            if (column.Count() != headers.Count())
            {
                throw new Exception($"column count '{column.Count()}' not the same as headers count'{headers.Count()}'");
            }

            string cardtypeString = column[Array.IndexOf(headers, "cardtype")].Trim('"').Trim();
            if (!int.TryParse(cardtypeString, out int cardtype))
            {
                throw new Exception($"cardtype='{cardtypeString}' is not a number");
            }

            var user = new ApplicationStore
            {
                Open = column[Array.IndexOf(headers, "open")].Trim('"').Trim(),
                Close = column[Array.IndexOf(headers, "close")].Trim('"').Trim(),
                City = column[Array.IndexOf(headers, "city")].Trim('"').Trim(),
                Country = column[Array.IndexOf(headers, "country")].Trim('"').Trim(),
                Email = column[Array.IndexOf(headers, "email")].Trim('"').Trim(),
                Palace = column[Array.IndexOf(headers, "palace")].Trim('"').Trim(),
                Id = Guid.NewGuid().ToString(),
                Name = column[Array.IndexOf(headers, "name")].Trim('"').Trim(),
                PhoneNumber = column[Array.IndexOf(headers, "phonenumber")].Trim('"').Trim(),
                UserName = column[Array.IndexOf(headers, "username")].Trim('"').Trim(),
                Street = column[Array.IndexOf(headers, "street")].Trim('"').Trim(),
                NormalizedEmail = column[Array.IndexOf(headers, "normalizedemail")].Trim('"').Trim(),
                NormalizedUserName = column[Array.IndexOf(headers, "normalizedusername")].Trim('"').Trim(),
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = column[Array.IndexOf(headers, "password")].Trim('"').Trim(), // Note: This is the password
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);

            return user;
        }
        IEnumerable<ApplicationStore> GetDefaultUser()
        {
            var user =
            new ApplicationStore()
            {
                City = "Da Nang",
                Country = "Viet Nam",
                Email = "minhvu@gmail.com",
                Id = Guid.NewGuid().ToString(),
                Open = "10AM",
                Name = "Canteen GRW",
                Close = "5PM",
                Palace= "GREENWICH UNIVERSITY",
                PhoneNumber = "1234567890",
                UserName = "minhvu",
                Street = "04 Ngo Quyen",
                NormalizedEmail = "MINHVU@GMAIL.COM",
                NormalizedUserName = "MINHVU@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123");

            return new List<ApplicationStore>()
            {
                user
            };
        }
        static string[] GetHeaders(string[] requiredHeaders, string csvfile)
        {
            string[] csvheaders = File.ReadLines(csvfile).First().ToLowerInvariant().Split(',');

            if (csvheaders.Count() != requiredHeaders.Count())
            {
                throw new Exception($"requiredHeader count '{ requiredHeaders.Count()}' is different then read header '{csvheaders.Count()}'");
            }

            foreach (var requiredHeader in requiredHeaders)
            {
                if (!csvheaders.Contains(requiredHeader))
                {
                    throw new Exception($"does not contain required header '{requiredHeader}'");
                }
            }

            return csvheaders;
        }
        static void GetPreconfiguredImages(string contentRootPath, string webroot, ILogger logger)
        {
            try
            {
                string imagesZipFile = Path.Combine(contentRootPath, "Setup", "images.zip");
                if (!File.Exists(imagesZipFile))
                {
                    logger.LogError("Zip file '{ZipFileName}' does not exists.", imagesZipFile);
                    return;
                }

                string imagePath = Path.Combine(webroot, "images");
                string[] imageFiles = Directory.GetFiles(imagePath).Select(file => Path.GetFileName(file)).ToArray();

                using (ZipArchive zip = ZipFile.Open(imagesZipFile, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        if (imageFiles.Contains(entry.Name))
                        {
                            string destinationFilename = Path.Combine(imagePath, entry.Name);
                            if (File.Exists(destinationFilename))
                            {
                                File.Delete(destinationFilename);
                            }
                            entry.ExtractToFile(destinationFilename);
                        }
                        else
                        {
                            logger.LogWarning("Skipped file '{FileName}' in zipfile '{ZipFileName}'", entry.Name, imagesZipFile);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "EXCEPTION ERROR: {Message}", ex.Message); ;
            }
        }
    }
}