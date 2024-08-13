var builder = DistributedApplication.CreateBuilder(args);

var sqlPassword = builder.AddParameter("sql-password", secret: true);

var sqlserver = builder.AddSqlServer("sqlserver", password: sqlPassword).WithDataVolume();

var discgolfDb = sqlserver.AddDatabase("discgolfdb");

builder.AddProject<Projects.DotnetAspire_DbUp>("dotnetaspire-dbup").WithReference(discgolfDb);

var webapi = builder.AddProject<Projects.DotnetAspire_WebApi>("dotnetaspire-webapi").WithReference(discgolfDb).WithExternalHttpEndpoints();

builder.AddNpmApp("frontend", "../dotnetaspire.frontend")
    .WithReference(webapi)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
