using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Bills;
using WebApi.Models.Cars;
using WebApi.Models.Comments;
using WebApi.Models.Posts;
using WebApi.Models.RentAds;
using WebApi.Models.Requests;
using WebApi.Models.SaleAds;
using WebApi.Models.TicketAnswers;
using WebApi.Models.Tickets;
using WebApi.Models.Users;

namespace WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
            CreateMap<CarCreateModel, Car>();
            CreateMap<BillCreateModel, Bill>();
            CreateMap<PostCreateModel, Post>();
            CreateMap<CommentCreateModel, Comment>();
            CreateMap<SaleAdCreateModel, SaleAd>();
            CreateMap<RentAdCreateModel, RentAd>();
            CreateMap<RequestCreateModel, Request>();
            CreateMap<TicketAnswerCreateModel, TicketAnswer>();
            CreateMap<TicketCreateModel, Ticket>();
        }
    }
}