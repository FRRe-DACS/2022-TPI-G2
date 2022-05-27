using AutoMapper;
using FanturApp.Repository.Dtos;
using FanturApp.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanturApp.Repository.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Package, PackageDto>().ReverseMap(); 
            //CreateMap<PackageDto, Package>();
            CreateMap<Passenger, PassengerDto>().ReverseMap(); 
            //CreateMap<PassengerDto, Passenger>();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            //CreateMap<ReservationDto, Reservation>();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            //CreateMap<PaymentDto, Payment>();
            CreateMap<Service, ServiceDto>().ReverseMap();
            //CreateMap<ServiceDto, Service>();
            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<UserDto, User>();

        }
    }
}
