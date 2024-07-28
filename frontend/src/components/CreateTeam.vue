<script setup>
import {addTeam, addFile} from './store.js';
</script>

<template>
  <div id="uploadwrapper" v-if="addTeam.visible">
    <form>
      <button id="close" type="button" @click="addTeam.close()">
        <img src="./icons/close_black.png">
      </button>
      <label for="title">Teamname</label>
      <input type="text" name="title" id="title" placeholder="Name">
      <label for="title">Teamnumber</label>
      <input type="text" name="title" id="title" placeholder="e.g. 1234">

      <button type="submit">Create</button>

    </form>
  </div>
</template>

<style scoped>

#close {
  border: 0;
  background: none;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  margin-bottom: 10px;
}

#close img {
  width: 15px;
  height: 15px;
}

#uploadwrapper {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(0, 0, 0, 0.5);
}

form {
  position: relative;
  background-color: white;
  padding: 50px 40px;
  padding-top: 40px;
  margin: auto;
  display: flex;
  flex-direction: column;
}

input {
  border: 0;
  outline: 0;
  height: 60px;
  margin-top: 10px;
  padding-bottom: 15px;

}

input[type="file"] {
  border: 0;
  outline: 0;
}

input::file-selector-button {
  border: 0;
  background-color: gray;
  color: white;
  height: 25px;
  border-radius: 5px;
}

button {
  height: 30px;
  background-color: black;
  color: white;
  border: 0;
  border-radius: 10px;
}

</style>