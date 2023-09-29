using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using UserProfileService.Data;
using UserProfileService.Model;
using UserProfileService.Service.IService;

namespace UserProfileService.Service
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ProfileService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }


        public List<ProfileModel> FetchUserDataByUserId(string userId)
        {
            List<ProfileModel> profiles = new List<ProfileModel>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (var command = new SqlCommand("FetchUserDataByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserId", userId));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            profiles.Add(new ProfileModel
                            {
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                Address = reader["Address"].ToString(),
                                Identifications = reader["Identifications"].ToString(),
                                PhoneNo = reader["PhoneNo"].ToString(),
                                Rpid = reader["Rpid"].ToString(),
                                PKID = reader["PKID"].ToString(),
                                Slot = reader["Slot"].ToString(),
                                VehicleNo = reader["VehicleNo"].ToString(),
                                PaymentDate = Convert.ToDateTime(reader["PaymentDate"]),
                                ReceiptNumber = reader["ReceiptNumber"].ToString(),
                                Amount = Convert.ToDecimal(reader["Amount"]),
                                location = reader["location"].ToString(),
                                Bookdate = Convert.ToDateTime(reader["Available"]),
                                checkIn = reader["CheckIn"].ToString(),
                                Checkout = reader["CheckOut"].ToString(),

                            }) ;
                        }
                    }
                }
            }

            return profiles;
        }
        public ProfileModel FetchUserDataByUserEmail(string userEmail)
        {
            ProfileModel profile = null;

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();

                using (var command = new SqlCommand("FetchUserProfileByUserId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@UserEmail", userEmail));

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            profile = new ProfileModel
                            {
                                Name = reader["Name"].ToString(),
                                Email = reader["Email"].ToString(),
                                UserName = reader["UserName"].ToString(),
                                PhoneNo = reader["PhoneNumber"].ToString()
                            };
                        }
                    }
                }
            }

            return profile;
        }



    }
}
