using Model;
using Repository;
using Repository.Persistence;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TeamService
    {
        ModelUOW db = new ModelUOW(new InfTeamApiDBContext());

        public IEnumerable<Team> GetTeams()
        {
            return db.Teams.GetAll();
        }

        public Team GetTeam(int id)
        {
            return db.Teams.Get(id) ;
        }


        public void Add(Team team)
        {
            db.Teams.Add(team);
            db.Complete();
        }

        public bool Delete(Team team)
        {
            if (team == null)
            {
                return false;
            }
            db.Teams.Remove(team);
            db.Complete();
            return true;
        }

        public bool UpdateTeam(Team team)
        {
            try
            {
                db.Teams.Update(team);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

