using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void EnsureHavingChatStates(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatState>()
                .HasData(
                new ChatState
                {
                    Id = 1,
                    State = "Set name"
                }, 
                new ChatState
                {
                    Id = 2,
                    State = "Set age"
                },
                new ChatState
                {
                    Id = 3,
                    State = "Set photo"
                }, 
                new ChatState
                {
                    Id = 4,
                    State = "Menu"
                },
                new ChatState
                {
                    Id = 5,
                    State = "Rate"
                }, 
                new ChatState
                {
                    Id = 6,
                    State = "Settings"
                }, 
                new ChatState
                {
                    Id = 7,
                    State = "Change name"
                },
                new ChatState
                {
                    Id = 8,
                    State = "Change age"
                }, 
                new ChatState
                {
                    Id = 9,
                    State = "Change photo"
                });
        }
    }
}
