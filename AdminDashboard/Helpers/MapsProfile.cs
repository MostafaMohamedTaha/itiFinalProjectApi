using AdminDashboard.Models;
using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.APIs.Helpers;
using Talabat.Core.Entities;

namespace AdminDashboard.Helpers
{
    public class MapsProfile:Profile
    {
        public MapsProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
