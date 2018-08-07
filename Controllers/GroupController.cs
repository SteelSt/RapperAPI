using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RapperAPI.Controllers {
    public class GroupController : Controller {
        List<Group> allGroups {get; set;}
        public GroupController() {
            allGroups = JsonToFile<Group>.ReadJson();
        }

        [HttpGet("groups")]
        public string Groups()
        {
            string AllTheGroups = "Here is a list of all groups:\n========================\n";
            foreach(Group group in allGroups)
            {
                AllTheGroups += "Group Name: " + group.GroupName + "\n";
            }
            return AllTheGroups;
        }

        [HttpGet("~/groups/name/{name}")]
        public string GroupName(string name)
        {
            string GroupNames = $"Here is a list of groups whose name includes {name}:\n========================\n";
            IEnumerable<Group> GroupNameContains = allGroups.Where(p => p.GroupName.Contains(name));
            foreach(Group group in GroupNameContains )
            {
                GroupNames += "Group Name: " + group.GroupName + "\n";
            }
            return GroupNames;
        }

        [HttpGet("~/groups/groupid/{num}")]
        public string GroupId(int num)
        {
            string GroupId = $"Here is the group with the Group ID {num}:\n========================\n";
            IEnumerable<Group> GroupIdIs = allGroups.Where(p => p.Id == num);
            foreach(Group group in GroupIdIs)
            {
                GroupId += "Group Name: " + group.GroupName + "\n";
            }
            return GroupId;
        }

    }
}