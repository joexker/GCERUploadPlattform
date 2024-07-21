<script setup>

  const handleSubmit = (e) => {
    e.preventDefault();
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    if (username === 'admin' && password === 'admin') {
      alert('You have successfully logged in');
    } else {
      alert('Invalid Credentials');
    }
  };
</script>

<template>
  <!--    <div class="background">-->
  <!--      <div class="shape"></div>-->
  <!--      <div class="shape"></div>-->
  <!--    </div>-->
  <form>
    <h3>Login</h3>
    <label for="username">Username</label>
    <input type="text" id="username" name="username" placeholder="Username">
    <label for="password">Password</label>
    <input type="password" id="password" name="password" placeholder="Password">
    <button type="submit" v-on:click="handleSubmit">Log In</button>
  </form>
</template>

<style scoped>

*:before,
*:after {
  padding: 0;
  margin: 0;
  box-sizing: border-box;
}

.background {
  width: 430px;
  height: 520px;
  position: relative;
  margin: auto
}

.background .shape {
  height: 200px;
  width: 200px;
  position: relative;
  border-radius: 50%;
}



.shape:first-child {
  background: linear-gradient(
      #1845ad,
      #23a2f6
  );
  left: -80px;
  top: -80px;
}

.shape:last-child {
  background: linear-gradient(
      to right,
      #ff512f,
      #f09819
  );
  right: -30px;
  bottom: -80px;
}

form {

  background-color: rgba(255, 255, 255, 0.13);
  position: absolute;
  transform: translate(-50%, -50%);
  top: 50%;
  left: 50%;
  border-radius: 10px;
  backdrop-filter: blur(10px);
  border: 2px solid rgba(255, 255, 255, 0.1);
  padding: 50px 35px;
}


/* Extra small devices (phones, 600px and down) */
@media only screen and (max-width: 600px) {
  form {
    width: 70%;
  }
}

/* Small devices (portrait tablets and large phones, 600px and up) */
@media only screen and (min-width: 600px) {
  form {
    width: 50%;
  }
}

/* Medium devices (landscape tablets, 768px and up) */
@media only screen and (min-width: 768px) {
  form {
    width: 50%;
  }
}

/* Large devices (laptops/desktops, 992px and up) */
@media only screen and (min-width: 992px) {
  form {
    width: 40%;
  }
}

/* Extra large devices (large laptops and desktops, 1200px and up) */
@media only screen and (min-width: 1200px) {
  form {
    width: 30%;
  }
}

form * {
  font-family: 'Poppins', sans-serif;
  color: #ffffff;
  letter-spacing: 0.5px;
  outline: none;
  border: none;
}

form h3 {
  font-size: 32px;
  font-weight: 500;
  line-height: 42px;
  text-align: center;
}

label {
  display: block;
  margin-top: 30px;
  font-size: 16px;
  font-weight: 500;
}

input {
  display: block;
  height: 50px;
  width: 100%;
  background-color: rgba(255, 255, 255, 0.07);
  border-radius: 3px;
  margin-top: 8px;
  font-size: 14px;
  font-weight: 300;
  text-indent: 10px;
}

::placeholder {
  color: #e5e5e5;
}

button {
  margin-top: 50px;
  width: 100%;
  background-color: #ffffff;
  color: #080710;
  padding: 15px 0;
  font-size: 18px;
  font-weight: 600;
  border-radius: 5px;
  cursor: pointer;
}
</style>