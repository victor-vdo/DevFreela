﻿using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.Projects.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetProjectByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
