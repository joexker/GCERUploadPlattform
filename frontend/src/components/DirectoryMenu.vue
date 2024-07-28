<script setup>

import {ref} from "vue";
import VIdeoPlayer from "@/components/VIdeoPlayer.vue";
import {currentTeamDir} from "@/components/store.js";

const directroies = ref([
  {
    Id: 1,
    Name: "Seeding Round 1"
  },
  {
    Id: 2,
    Name: "Seeding Round 2"
  },
  {
    Id: 3,
    Name: "Double Elimination"
  },
  {
    Id: 4,
    Name: "Finals"
  }
])

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
      <h1>Directories</h1>
    </header>
    <ul>
      <li v-for="dir in directroies" :id="dir.Id" class="team" @click="currentTeamDir.updateDir(dir.Id); currentTeamDir.setToDir()">
        <div id="team">{{ dir.Name }}</div>
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
  width: 50%;
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