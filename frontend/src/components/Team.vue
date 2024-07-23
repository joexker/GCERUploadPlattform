<script setup>
import {ref} from 'vue'
import TeamMenu from "@/components/TeamMenu.vue";

const itemRefs = ref([])

// api call to get directories
const directories = ref(["Seeding Round 1", "Seeding Round 2", "Double Elimination", "Finals"])

// api get team with id
const team = ref({
  Name: "Icebörg",
  TeamNumber: "#0606"

})

// api call to get files from team id number
const files = ref([
  {
    Title: "Video 1",
    videoPath: "video1.mp4"
  },
  {
    Title: "Image 4",
    videoPath: "image1.mp4"
  },
  {
    Title: "Image 2",
    videoPath: "image2.png"
  },
  {
    Title: "Image 3",
    videoPath: "image3.png"
  },
  {
    Title: "Image 4",
    videoPath: "image4.png"
  },
  {
    Title: "asdasihdiasjd",
    videoPath: "image5.mp4"
  },
  {
    Title: "Image 6",
    videoPath: "image6.png"
  },
  {
    Title: "Image 7",
    videoPath: "image7.png"
  },
  {
    Title: "Image 8",
    videoPath: "image8.png"
  },
  {
    Title: "Image 9",
    videoPath: "image9.png"
  },
  {
    Title: "Image 10",
    videoPath: "image10.png"
  },
  {
    Title: "Image 11",
    videoPath: "image11.png"
  },
  {
    Title: "Image 12",
    videoPath: "image12.png"
  },
  {
    Title: "Image 13",
    videoPath: "image13.png"
  },
  {
    Title: "Image 14",
    videoPath: "image14.png"
  },
  {
    Title: "Image 15",
    videoPath: "image15.png"
  },
  {
    Title: "Image 16",
    videoPath: "image16.png"
  },
  {
    Title: "Image 17",
    videoPath: "image17.png"
  },
  {
    Title: "Image 18",
    videoPath: "image18.png"
  },
  {
    Title: "Image 19",
    videoPath: "image19.png"
  },
  {
    Title: "Image 20",
    videoPath: "image20.png"
  },
  {
    Title: "Image 21",
    videoPath: "image21.png"
  },
  {
    Title: "Image 22",
    videoPath: "image22.png"
  }
])
</script>

<template>
  <div class="wrapper">
    <header>
      <div class="team_info">
        <div id="team"><span>{{ team.Name }}</span></div>
        <div id="teamnumber"><span>{{ team.TeamNumber }}</span></div>
      </div>
      <hr>
    </header>
    <ul>
      <li v-for="dir in directories" ref="itemRefs" class="directory">
        <img src="./icons/open-folder.png">
        <p>{{ dir }}</p>
      </li>
      <li v-for="file in files" ref="itemRefs"
          :class="{ video: file.videoPath.endsWith('.mp4'), image: file.videoPath.endsWith('.png')}">
        <img v-if="file.videoPath.endsWith('.mp4')" src="./icons/video.png">
        <img v-if="file.videoPath.endsWith('.png')" src="./icons/image.png">
        <p>{{ file.Title }}</p>
      </li>

      <!--      <li class="directory">-->
      <!--        <img src="./open-folder.png">-->
      <!--        <p>Directory 1</p>-->
      <!--      </li>-->
      <!--      <li class="directory">-->
      <!--        <img src="./open-folder.png">-->
      <!--        <p>Directory 2</p>-->
      <!--      </li>-->
      <!--      <li class="video">-->
      <!--        <img src="./video.png">-->
      <!--        <p>Video 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
      <!--      <li class="image">-->
      <!--        <img src="./image.png">-->
      <!--        <p>Image 1</p>-->
      <!--      </li>-->
    </ul>
    <footer>
      <button>
        <img src="./icons/upload.png">
      </button>
    </footer>
  </div>
  <TeamMenu />
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

button * {
  height: 60%;
}
</style>