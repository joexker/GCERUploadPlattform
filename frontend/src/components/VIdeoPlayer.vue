<script setup>

import {addDir, video} from './store.js';
// defineProps(['visible', 'file-id'])

defineProps({
  visible: Boolean,
  fileId: Number
})

import {ref} from "vue";


const comments = ref(
    [
      {
        "id": 0,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 1,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 2,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 3,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 4,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 5,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 6,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 7,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 8,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 9,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 10,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      },
      {
        "id": 11,
        "title": "Comment",
        "message": "Lorem Ipsum asdopasjdp"
      }
    ]
)

</script>

<template>
  <main v-if="video.visible">
    <button id="close" type="button" @click="video.close()">
      <img src="./icons/close.png">
    </button>
    <div class="videowrapper">
      <video controls>
        <source src="./video.mp4" type="video/mp4">
      </video>
      <div class="controls">
        <button class="next" @click="video.next()">
          <img src="./icons/next.png">
        </button>
        <button class="prev" @click="video.prev()">
          <img src="./icons/prev.png">
        </button>
      </div>
    </div>

    <ul>
      <li>
        <form class="commentform">
          <textarea cols="40" rows="5" placeholder="Your message"></textarea>
          <button type="submit">Send message</button>
        </form>
      </li>
      <li v-for="comment in comments" :id="comment.Id" class="comment">
        <p>{{ comment.title }}</p>
        <p>{{ comment.message }}</p>
        <p>{{ video.video }}</p>
      </li>
    </ul>
  </main>
</template>

<style scoped>

#close {
  position: fixed;
  border: 0;
  background: none;
  top: 10px;
  left: 10px;
}

#close img {
  width: 40px;
  height: 40px;
}

main {
  position: fixed;
  width: 100%;
  height: 100%;
  background-color: rgb(0, 0, 0, 0.65);
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  overflow-y: scroll;
}

.controls {
  position: relative;
  display: flex;
  flex-direction: row-reverse;
  justify-content: center;
  gap: 20px;
  width: 100%;
  z-index: 100;
  margin-top: 25px;
}

.controls img {
  height: 40px;
}

button {
  border: 0;
  border-radius: 10px;
}

.videowrapper {
  position: relative;
  height: 80%;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  margin-top: 15%;
}


ul {
  position: relative;
  width: 100%;
  height: 50%;
  display: flex;
  flex-direction: column;
  align-items: center;
  padding: 0;
  margin: 5% 0;
  overflow-y: scroll;
  -ms-overflow-style: none; /* IE and Edge */
  scrollbar-width: none; /* Firefox */
  gap: 15px;
}


li {
  display: flex;
  flex-direction: column;
  background-color: white;
  border-radius: 15px;
  padding: 15px;
  width: 90%;
}

ul li:first-child {
  height: 100%;
}

li .commentform {
  display: flex;
  flex-direction: column;
}

li .commentform button {
  height: 30px;
  background-color: black;
  color: white;
  border: 0;
}


.commentform textarea {
  height: 100px;
  resize: none;
  width: 100%;
  border: 0;
  outline: 0;
  padding-top: 5px;
}

.comment p:first-child {
  font-weight: bold;
}

.comment p:last-child {
  font-weight: 0;
}

video {
  width: 90%;
  border: 0;
  outline: 0;
}
</style>