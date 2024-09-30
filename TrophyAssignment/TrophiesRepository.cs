using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TrophyAssignment
{
    public class TrophiesRepository
    {
        private List<Trophy> _trophies = new List<Trophy>();
        private int _nextId;
        public int Count { get { return _trophies.Count; } }


        public TrophiesRepository()
        {
            _trophies.Add(new Trophy(1, "Iron Pony Competition1", 2023));
            _trophies.Add(new Trophy(2, "The Running of the Leaves2", 2022));
            _trophies.Add(new Trophy(3, "Best Young Flyer Competition3", 2021));
            _trophies.Add(new Trophy(4, "Sisterhooves Social4", 2020));
            _trophies.Add(new Trophy(5, "Equestria Games5", 2019));
        }

        public List<Trophy> Get(int? yearBefore = null, int? yearAfter = null, string? sortBy = null)
        {
            List<Trophy> trophies = _trophies;

            if (yearBefore != null)
                trophies = trophies.FindAll(t => t.Year < yearBefore);

            if (yearAfter != null)
                trophies = trophies.FindAll(t => t.Year > yearAfter);

            switch (sortBy)
            {
                case "Competition":
                    trophies = trophies.OrderBy(t => t.Competition).ToList();
                    break;

                case "Year":
                    trophies = trophies.OrderBy(t => t.Year).ToList(); 
                    break;
            }
            return trophies;
        }
        public Trophy GetById(int id)
        {
            foreach (Trophy trophy in _trophies)
            {
                if (trophy.Id == id) 
                    return trophy;
            }
            return null;
        }
        public Trophy Add(Trophy trophy) 
        {
            _nextId++;
            trophy.Id = _nextId;
            _trophies.Add(trophy);
            return trophy;
        }
        public Trophy Remove(int id)
        {
            Trophy trophy = GetById(id);
            if(trophy != null)
            {
                _trophies.Remove(trophy);
                return trophy;
            }
            return null;
        }
        public Trophy Update(int id, Trophy trophy)
        {
            foreach(Trophy trophy1 in _trophies)
            {
                if(trophy1.Id == id)
                {
                    trophy1.Competition = trophy.Competition;
                    trophy1.Year = trophy.Year;
                    return trophy1;
                }
            }
            return null;
        }
    }
}
