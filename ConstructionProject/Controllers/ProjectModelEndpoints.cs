using Microsoft.EntityFrameworkCore;
using ConstructionProject.Data;
using ConstructionProject.Model;
namespace ConstructionProject.Controllers;

public static class ProjectModelEndpoints
{
    public static void MapProjectModelEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/ProjectModel", async (ConstructionProjectContext db) =>
        {
            return await db.ProjectModel.ToListAsync();
        })
        .WithName("GetAllProjectModels");

        routes.MapGet("/api/ProjectModel/{id}", async (int Id, ConstructionProjectContext db) =>
        {
            return await db.ProjectModel.FindAsync(Id)
                is ProjectModel model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetProjectModelById");

        routes.MapPut("/api/ProjectModel/{id}", async (int Id, ProjectModel projectModel, ConstructionProjectContext db) =>
        {
            var foundModel = await db.ProjectModel.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(projectModel);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateProjectModel");

        routes.MapPost("/api/ProjectModel/", async (ProjectModel projectModel, ConstructionProjectContext db) =>
        {
            db.ProjectModel.Add(projectModel);
            await db.SaveChangesAsync();
            return Results.Created($"/ProjectModels/{projectModel.Id}", projectModel);
        })
        .WithName("CreateProjectModel");

        routes.MapDelete("/api/ProjectModel/{id}", async (int Id, ConstructionProjectContext db) =>
        {
            if (await db.ProjectModel.FindAsync(Id) is ProjectModel projectModel)
            {
                db.ProjectModel.Remove(projectModel);
                await db.SaveChangesAsync();
                return Results.Ok(projectModel);
            }

            return Results.NotFound();
        })
        .WithName("DeleteProjectModel");
    }
}
