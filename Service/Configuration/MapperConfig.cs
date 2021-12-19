using Mapster;
using Repository.Models;
using Shared.DTOLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Configuration
{
    public static class MapperConfig
    {
        public static void RegisterUserMapping()
        {
            TypeAdapterConfig<User, UserAuth>.NewConfig()
                .Map(dest => dest.Id,
                    src => src.Id)
                .Map(dest => dest.Email,
                    src => src.Email)
                .Map(dest => dest.UserName,
                    src => src.UserName);
        }

        public static void RegisterPlayerMapping()
        {
            TypeAdapterConfig<Player, PlayerDTO>.NewConfig()
                .Map(dest => dest.TeamID,
                     src => src.Team.Id,
                     src => src.Team != null);
            TypeAdapterConfig<PlayerDTO, Player>.NewConfig();
        }

        public static void RegisterSeasonMapping()
        {
            TypeAdapterConfig<Season, SeasonDTO>.NewConfig()
                .Map(dest => dest.LeagueID,
                     src => src.League.Id,
                     src => src.League != null);
            TypeAdapterConfig<SeasonDTO, Season>.NewConfig();
        }

        public static void RegisterTeamMapping()
        {
            TypeAdapterConfig<Team, TeamDTO>.NewConfig()
                .Map(dest => dest.LeagueID,
                     src => src.League.Id,
                     src => src.League != null);
            TypeAdapterConfig<TeamDTO, Team>.NewConfig();
        }
    }
}
