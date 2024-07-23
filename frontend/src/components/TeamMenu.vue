<script setup>

import {ref} from "vue";

const teams = ref([
  {
    Id: 1,
    Name: "Icebörg",
    TeamNumber: "#0606"
  },
  {
    Id: 2,
    Name: "Team 2",
    TeamNumber: "#0002"
  },
  {
    Id: 3,
    Name: "Team 3",
    TeamNumber: "#0003"
  },
  {
    Id: 4,
    Name: "Team 4",
    TeamNumber: "#0004"
  },
  {
    Id: 5,
    Name: "Team 5",
    TeamNumber: "#0005"
  },
  {
    Id: 6,
    Name: "Team 6",
    TeamNumber: "#0006"
  },
  {
    Id: 7,
    Name: "Team 7",
    TeamNumber: "#0007"
  },
  {
    Id: 8,
    Name: "Team 8",
    TeamNumber: "#0008"
  },
  {
    Id: 9,
    Name: "Team 9",
    TeamNumber: "#0009"
  },
  {
    Id: 10,
    Name: "Team 10",
    TeamNumber: "#0010"
  },
  {
    Id: 11,
    Name: "Team 11",
    TeamNumber: "#0011"
  },
  {
    Id: 12,
    Name: "Team 12",
    TeamNumber: "#0012"
  },
  {
    Id: 13,
    Name: "Team 13",
    TeamNumber: "#0013"
  },
  {
    Id: 14,
    Name: "Team 14",
    TeamNumber: "#0014"
  },
  {
    Id: 15,
    Name: "Team 15",
    TeamNumber: "#0015"
  },
  {
    Id: 16,
    Name: "Team 16",
    TeamNumber: "#0016"
  },
  {
    Id: 17,
    Name: "Team 17",
    TeamNumber: "#0017"
  },
  {
    Id: 18,
    Name: "Team 18",
    TeamNumber: "#0018"
  },
  {
    Id: 19,
    Name: "Team 19",
    TeamNumber: "#0019"
  }])

var menuclosed = ref(true)
const itemRefs = ref([])

</script>

<template>
  <a class="teammenu" @click="menuclosed = false">
    <img src="./icons/menu.png">
  </a>
  <div class="teams" :hidden="menuclosed">
    <header>
      <div @click="menuclosed = true">
        <img src="./icons/close.png">
      </div>
      <h1>Teams</h1>
    </header>
    <ul>
      <li v-for="team in teams" :id="team.Id" ref="itemRefs" class="team">
        <div id="team">{{ team.Name }}</div>
        <div id="teamnumber">{{ team.TeamNumber }}</div>
      </li>
    </ul>
  </div>
</template>

<style scoped>

.teammenu {
  position: absolute;
  top: 25px;
  left: 15px;
  height: 50px;
  width: 50px;
  display: flex;
  align-items: center;
  justify-content: center;
  background: none;
  border: 0;
}

.teammenu img {
  height: 75%;
}

.teams {
  height: 100vh;
  width: 50%;
  position: fixed;
  top: 0;
  left: 0;
  background: black;
  overflow-y: scroll;
  -ms-overflow-style: none;  /* IE and Edge */
  scrollbar-width: none;  /* Firefox */
  z-index: 5;
}

.teams::-webkit-scrollbar {
  display: none;
}

header {
  position: fixed;
  background-color: black;
  width: 100%;
  height: 80px;
  display: flex;
  align-items: center;
  font-size: 15px;
}

header h1 {
  color: white;
  text-align: center;
  margin: auto;
}

.teams ul {
  list-style-type: none;
  padding: 65px 0 0 0;
  color: white;
}

header div {
  position: absolute;
  left: 20px;
  height: 25px;
  width: 25px;
}

header div img {
  height: 100%;
  width: 100%;
}

@media only screen and (max-width: 600px) {
  .teams {
    width: 100%;
  }

  header {
    font-size: 15px;
  }
}

.team {
  display: flex;
  justify-content: space-between;
  font-size: 25px;
  padding: 15px;
  border-radius: 10px;
  margin: 10px;
  background-color: rgb(255, 255, 255, 0.13);
}
</style>