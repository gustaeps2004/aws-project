<template>
  <div class="template-main">
    <div class="form-submit">
      <h3>Log In</h3>
      <div  class="inputs">
        <input type="email" required v-model="model.username" placeholder="Enter your e-mail" class="inputs-texts">
        <br>
        <br>
        <input type="password" required v-model="model.password" placeholder="Enter your password" class="inputs-texts">
        <br>
        <button class="button-submit" @click="onSubmit">Enter</button>
      </div>
    </div>
  </div>
</template>

<script>
import api from 'axios'

export default {
  name: "Login",
  data() {
    return {
      model: {
        username: '',
        password: ''
      },
      url: 'https://localhost:44393/api/authentication'
    };
  },
  methods: {
    onSubmit() {
      let th = this

      api.get(th.url + `/access?username=${th.model.username}&password=${th.model.password}`)
      .then( (response) => {
        
        if (response.data.firstAccess === true){
          this.$router.push('/request-mfa')
        }
        else {
          // this.$router.push('/dashboard')
        }

      })
      .catch( (error) => {
        console.log(error)
      })
    }
  },
};
</script>

<style scoped>
.template-main{
  width: 100vw;
  height: 100vh;
  display: flex;
  justify-content: center;
  align-items: center;
  background-color: rgb(206, 206, 206);
}

.form-submit{
  width: 20vw;
  height: 50vh;
  background-color: rgb(255, 255, 255);
}

.inputs{
  height: 50%;
  padding: 15px;
}

.button-submit{
  width: 100px;
  height: 30px;
  margin-top: 40px;
  cursor: pointer;
  transition: 0.7s;
  border-radius: 5px;
  border: none;
  color: white;
  background: rgb(0, 122, 255);
}

.button-submit:hover{
  transition: 0.7s;
  color: rgb(0, 122, 255);
  border: 2px solid rgb(0, 122, 255);
  background-color: white;
}

.inputs-texts{
  width: 250px;
  height: 20px;
  border: 1px solid black;
  border-radius: 5px;
}
</style>