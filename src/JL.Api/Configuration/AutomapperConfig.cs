using AutoMapper;
using JL.Api.ViewModels;
using JL.Business.Models.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JL.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Funcionario, FuncionarioViewModel>().ReverseMap();
        }
    }
}
