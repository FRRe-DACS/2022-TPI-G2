using AutoMapper;
using FanturApp.CrossCutting.Dtos;
using FanturApp.CrossCutting.Models;

namespace FanturApp.CrossCutting.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<Package, PackageWithServiceDto>().ReverseMap();
            CreateMap<PackageService, PackageServiceDto>().ReverseMap();
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
