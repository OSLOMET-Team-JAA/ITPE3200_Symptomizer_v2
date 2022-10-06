using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ITPE3200_Symptomizer.DAL
{
    public class DB_Init
    {
        public static void Init(IApplicationBuilder app) {
            using (var serScope = app.ApplicationServices.CreateScope())
            {
                var context = serScope.ServiceProvider.GetRequiredService<PatientContext>();

                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var patient1 = new Patients { };
                var patient2 = new Patients { };
            }
        }
    }
}
