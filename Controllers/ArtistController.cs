using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RapperAPI.Controllers {

    
    public class ArtistController : Controller {

        private List<Artist> allArtists;

        public ArtistController() {
            allArtists = JsonToFile<Artist>.ReadJson();
        }

        //This method is shown to the user navigating to the default API domain name
        //It just display some basic information on how this API functions
        [Route("")]
        [HttpGet]
        public string Index() {
            //String describing the API functionality
            string instructions = "Welcome to the Music API~~\n========================\n";
            instructions += "    Use the route /artists/ to get artist info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *RealName/{string}\n";
            instructions += "       *Hometown/{string}\n";
            instructions += "       *GroupId/{int}\n\n";
            instructions += "    Use the route /groups/ to get group info.\n";
            instructions += "    End-points:\n";
            instructions += "       *Name/{string}\n";
            instructions += "       *GroupId/{int}\n";
            instructions += "       *ListArtists=?(true/false)\n";
            return instructions;
        }

        ////WORKING
        [HttpGet("artists")]
        public string Artists()
        {
            string AllTheArtists = "Here is a list of all artists:\n========================\n";
            foreach(Artist artist in allArtists)
            {
                AllTheArtists += "Real Name: " + artist.RealName + " - Stage Name: " + artist.ArtistName + " - Age: " + artist.Age + " - Hometown: " + artist.Hometown + "\n";
            }
            return AllTheArtists;
        }

        ////WORKING
        [HttpGet("~/artists/realname/{name}")]
        public string RealName(string name)
        {
            string RealNames = $"Here is a list of artists whose name includes {name}:\n========================\n";
            IEnumerable<Artist> ArtistNameContains = allArtists.Where(p => p.RealName.Contains(name));
            foreach(Artist artist in ArtistNameContains )
            {
                RealNames += "Real Name: " + artist.RealName + " - Stage Name: " + artist.ArtistName + "\n";
            }
            return RealNames;
        }

        ////WORKING
        [HttpGet("~/artists/hometown/{name}")]
        public string Hometown(string name)
        {
            string HometownArtist = $"Here is a list of artists whose home town is {name}:\n========================\n";
            IEnumerable<Artist> HometownArtistQuery = allArtists.Where(p => p.Hometown == name);
            foreach(Artist artist in HometownArtistQuery )
            {
                HometownArtist += "Real Name: " + artist.RealName + " - Stage Name: " + artist.ArtistName + "\n";
            }
            return HometownArtist;
        }

        ////WORKING
        [HttpGet("~/artists/groupid/{num}")]
        public string GroupId(int num)
        {
            string ArtistGroup = $"Here is a list of artists whose Group ID is {num}:\n========================\n";
            IEnumerable<Artist> ArtistGroupQuery = allArtists.Where(p => p.GroupId == num);
            foreach(Artist artist in ArtistGroupQuery )
            {
                ArtistGroup += "Real Name: " + artist.RealName + " - Stage Name: " + artist.ArtistName + " - Group ID: " + artist.GroupId + "\n";
            }
            return ArtistGroup;
        }
    }
}