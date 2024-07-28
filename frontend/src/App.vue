<script setup>
import Login from "@/components/Login.vue";
import JoexBackground from "@/components/JoexBackground.vue";
import Team from "@/components/Team.vue";
import {ref} from "vue";
import TeamMenu from "@/components/TeamMenu.vue";
import Directory from "@/components/Directory.vue";
import CreateDir from "@/components/CreateDir.vue";
import VideoUpload from "@/components/VideoUpload.vue";
import DirectoryMenu from "@/components/DirectoryMenu.vue";
import VIdeoPlayer from "@/components/VIdeoPlayer.vue";
import { currentTeamDir } from './components/store.js';
import CreateTeam from "@/components/CreateTeam.vue";

const comments = ref([
  {
    "title" : "Comment"
  }
])

</script>

<template>

  <main>
    <JoexBackground />
    <Directory v-if="!currentTeamDir.isTeam" />
    <Team v-if="currentTeamDir.isTeam"/>
    <VIdeoPlayer></VIdeoPlayer>
    <VideoUpload />
    <CreateDir />
    <CreateTeam />
  </main>
</template>

<style scoped>

* {
  font-family: 'Roboto', sans-serif;
}
header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

@media (min-width: 1024px) {
  header {
    display: flex;
    place-items: center;
    padding-right: calc(var(--section-gap) / 2);
  }

  .logo {
    margin: 0 2rem 0 0;
  }

  header .wrapper {
    display: flex;
    place-items: flex-start;
    flex-wrap: wrap;
  }
}


</style>
