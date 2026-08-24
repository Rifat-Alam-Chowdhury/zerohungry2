using AutoMapper;
using BAL.Model;

//using BLL.Models;
using DAL.EF.Tables;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<RestaurantModel, Restaurant>().ReverseMap();
            CreateMap<EmployeeModel, Employee>().ReverseMap();
            CreateMap<CollectionRequestModel, DAL.EF.Tables.CollectionRequest>().ReverseMap();




        }


    }
}
