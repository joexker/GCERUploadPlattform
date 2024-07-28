<script setup>
import {reactive, ref} from 'vue'
import TeamMenu from "@/components/TeamMenu.vue";
import DirectoryMenu from "@/components/DirectoryMenu.vue";
import VideoUpload from "@/components/VideoUpload.vue";
import VIdeoPlayer from "@/components/VIdeoPlayer.vue";
import {video, addFile, addDir, addTeam, currentTeamDir} from './store.js';
import CreateDir from "@/components/CreateDir.vue";

function toggleAddOptions() {
  const addoptions = document.getElementById('addOptions');

  if (addoptions.classList.contains("hidden")) {
    addoptions.classList.remove("hidden")
    return;
  }

  addoptions.classList.add("hidden");
}



const itemRefs = ref([])

// api get team with id
const team = ref({
  Name: "Icebörg",
  TeamNumber: "#0606"

})

const directory = ref({
  name: "Seeding Round 1"
})

// api call to get files from team id number
const files = ref([
  {
    Title: "Video 1",
    videoPath: "video1.mp4",
    Id: 0
  },
  {
    Title: "Image 4",
    videoPath: "image1.mp4",
    Id: 1
  },
  {
    Title: "Image 2",
    videoPath: "image2.png",
    Id: 2
  },
  {
    Title: "Image 3",
    videoPath: "image3.png",
    Id: 3
  },
  {
    Title: "Image 4",
    videoPath: "image4.png",
    Id: 4
  },
  {
    Title: "asdasihdiasjd",
    videoPath: "image5.mp4",
    Id: 5
  },
  {
    Title: "Image 6",
    videoPath: "image6.png",
    Id: 6
  },
  {
    Title: "Image 7",
    videoPath: "image7.png",
    Id: 7
  },
  {
    Title: "Image 8",
    videoPath: "image8.png",
    Id: 8
  },
  {
    Title: "Image 9",
    videoPath: "image9.png",
    Id: 9
  },
  {
    Title: "Image 10",
    videoPath: "image10.png",
    Id: 10
  },
  {
    Title: "Image 11",
    videoPath: "image11.png",
    Id: 11
  },
  {
    Title: "Image 12",
    videoPath: "image12.png",
    Id: 12
  },
  {
    Title: "Image 13",
    videoPath: "image13.png",
    Id: 13
  },
  {
    Title: "Image 14",
    videoPath: "image14.png",
    Id: 14
  },
  {
    Title: "Image 15",
    videoPath: "image15.png",
    Id: 15
  },
  {
    Title: "Image 16",
    videoPath: "image16.png",
    Id: 16
  },
  {
    Title: "Image 17",
    videoPath: "image17.png",
    Id: 17
  },
  {
    Title: "Image 18",
    videoPath: "image18.png",
    Id: 18
  }
])
</script>

<template>
  <div class="wrapper">
    <button class="goHome" @click="currentTeamDir.setToTeam()">
      <img src="./icons/home.png">
    </button>
    <header>
      <div class="team_info">
        <div id="team"><span>{{ team.Name }}</span></div>
        <div id="teamnumber"><span>{{ team.TeamNumber }}</span></div>
        <div><span>{{ directory.name }}</span></div>
      </div>
      <hr>
    </header>
    <ul>
      <li v-for="file in files" ref="itemRefs" v-bind:id="file.Id"
          :class="{ video: file.videoPath.endsWith('.mp4'), image: file.videoPath.endsWith('.png')}"
          @click="video.updateVideo(file.Id)">
        <img v-if="file.videoPath.endsWith('.mp4')" src="./icons/video.png">
        <img v-if="file.videoPath.endsWith('.png')" src="./icons/image.png">
        <p>{{ file.Title }}</p>
      </li>

    </ul>
    <footer>
      <div id="addOptions" class="hidden" tabindex="0">
        <button id="file" @click="addFile.toggle(), toggleAddOptions()">
          File
        </button>
        <button id="dir" @click="addDir.toggle(), toggleAddOptions()">
          Directory
        </button>
        <button id="dir" @click="addTeam.toggle(), toggleAddOptions()">
          Team
        </button>
      </div>
      <button id="addbtn" @click="toggleAddOptions">
        <img src="./icons/add.png">
      </button>
    </footer>
  </div>
  <DirectoryMenu/>
</template>

<style scoped>
.wrapper {
  display: flex;
  flex-direction: column;
  height: 100%;
  width: 100%;
  position: absolute;
  left: 0;
  top: 0;
}

header {
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 100%;
  position: relative;
  padding: 30px 0;

}

.team_info {
  width: 100%;
  height: 50px;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  padding-bottom: 15px;
}

.team_info * {
  color: white;
  font-size: 1.5rem;
  font-weight: 500;
}


hr {
  border-top: 2px solid white;
  border-radius: 4px;
  width: 90%;
}

ul {
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 0;
  overflow: auto;
}

.directory, .video, .image {
  position: relative;
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 90%;
  height: 50px;
  border-radius: 10px;
  backdrop-filter: blur(10px);
  border: 2px solid rgba(255, 255, 255, 0.1);
  padding: 20px;
  margin-bottom: 15px;
}

.directory {
  background-color: rgba(255, 255, 255, 0.13);
}

.video {
  background-color: rgba(135, 206, 250, 0.45);
}

.image {
  background-color: rgba(255, 255, 0, 0.45);
}


@media only screen and (max-width: 600px) {
  .directory, .video, .image {
    width: 80%;
  }
}

.directory *, .video *, .image * {
  gap: 30px;
}

.directory img, .video img, .image img {
  height: 100%;
}

.directory p, .video p, .image p {
  color: white;
  font-size: 1.5rem;
  font-weight: 500;
}

footer {
  position: fixed;
  width: 100%;
  display: flex;
  justify-content: flex-end;
  align-items: center;
  bottom: 0;
  height: 50px;
  padding: 20px 0;
  gap: 30px;
  margin: 0 0 20px -20px;
}

footer button {
  height: 75px;
  width: 75px;
  background-color: white;
  border-radius: 100px;
  border: 0;
  display: flex;
  justify-content: center;
  align-items: center;
}

#addOptions {
  position: absolute;
  bottom: 100px;
  right: 10px;
  width: 150px;
  height: 200px;
  padding: 20px;
  background-color: white;
  border: 0;
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-direction: column;
  border-radius: 10px;
}

.hidden {
  visibility: hidden;
}

#addOptions button {
  width: 100%;
  height: 50px;
  background-color: black;
  color: white;
  font-weight: bold;
  border-radius: 10px;

}

button * {
  height: 50%;
}

.goHome {
  position: absolute;
  top: 0;
  right: 0;
  width: 50px;
  height: 50px;
  background-color: white;
  border-radius: 10px;
  margin: 25px;
  display: flex;
  justify-content: center;
  align-items: center;
  padding: 0;
  z-index: 100;
}

.goHome img {
  width: 50%;
  height: 50%;
}
</style>