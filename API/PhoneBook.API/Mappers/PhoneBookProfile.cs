using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Mappers
{
    public class PhoneBookProfile: Profile
    {
        public PhoneBookProfile()
        {
            CreateMap<ML.PhoneBook, VM.PhoneBookViewModel>()
                .ForMember(mp => mp.Entries, opt => opt.MapFrom(src => src.Entries))
                .ReverseMap();

            CreateMap<ML.Entry, VM.EntryViewModel>()
                .ReverseMap();
        }
    }
}
