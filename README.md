To add Swagger:
1. Add Swashbuckle.AspNetCore
- Install-Package Swashbuckle.AspNetCore -Version 4.0.1
- dotnet add package Swashbuckle.AspNetCore --version 4.0.1

2. Saul.Test.Services.WebAPI/Properties/launchSettings.json Change:
- from       "launchUrl": "api/values",
- to:        "launchUrl": "swagger/index.html",

3. Saul.Test.Services.WebAPI/Startup.cs
In ConfigureServices at the end, Add:

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Saul Test",
                    Description = "Studying Architecture",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Saul Chipana",
                        Email = "Saul.Dev09@gmail.com",
                        Url = ""
                    },
                    License = new License
                    {
                        Name = "Use to Study",
                        Url = ""
                    }
                });
            });

In Configure, before app.UseMvc();, Add:

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });
   
5. Verify in controller, Route:  [Route("api/[controller]/[action]")], with [] not with {}

Detail [here](https://github.com/SaulDev09/.Net-DDD/commit/9a8d5422987aad19be8a44c8ae65da707cd86e9c):


Docker:
------------

        cd C:\FOLDER
        docker image build -t saul.test:1.0.1 -f .\Saul.Test.Services.WebAPI\Dockerfile .
        docker image ls
        docker container run --name saul.test -d -p 8050:80 IMAGE_ID
        docker container ls
        docker container logs CONTAINER_ID
           
localhost:8050/swagger