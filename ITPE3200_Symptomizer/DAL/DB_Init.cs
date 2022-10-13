﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ITPE3200_Symptomizer.DAL
{
    public class DBinit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PatientContext>();

                // -- We will not keep our database, so we need each time delete it after seeding
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //--- Making data for our database initialization -----------//
                var disease1 = new Diseases { Symptoms = "Fever or chills,Cough,Sore throat,High temperature,Muscle or body aches", DiseaseName = "Flu" };
                var disease2 = new Diseases { Symptoms = "Fever or chills,Cough,Sore throat,High temperature,Shortness of breath or difficulty breathing,Muscle or body aches", DiseaseName = "COVID-19" };

                var patient1 = new Patients { Firstname = "Ole", Lastname = "Hansen", Disease = disease1 };
                var patient2 = new Patients { Firstname = "Per", Lastname = "Jensen", Disease = disease2 };

                //--Add pre-created Patients to context (Database) ----------//
                context.Patients.Add(patient1);
                context.Patients.Add(patient2);

                //----Some referrences --------------------------------------//
                //https://www.cdc.gov/flu/symptoms/symptoms.htm
                //https://www.cdc.gov/coronavirus/2019-ncov/symptoms-testing/symptoms.html
                //https://oslomet.instructure.com/courses/24253/pages/kunde-ordre-eksempel?module_item_id=452353


                context.SaveChanges();
            }
        }
    }
}