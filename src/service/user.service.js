import axios from "axios";

const baseUrl = "https://localhost:7190/api";

export const postUser = async (data) => {
  const endpoint = `${baseUrl}/User`
  const post = {
    firstName: data.firstName,
    lastName: data.lastName,
    email: data.email,
    passWord: data.password,
    userName: data.username,
    phoneNumber: data.phoneNumber,
    emailSubscription: data.emailSubscription,
    role: "Customer"
   
  
  }
  return await(
    axios.post(
      endpoint, post
    )
    .then(
      (res) => {
        return res
      }
    )
    .catch(
      (err) => {
        return err
      }
    )
  )
}

export const loginUser = async (userName, password) => {
  const endpoint = `${baseUrl}/Login`
  const post = {
    userName: userName,
    passWord: password
  }

  return (
    await axios.post(
      endpoint, post
    )
      .then(
        (res) => {
          console.log(res);
          return res;
        }
      )
      .catch(
        (err) => {
          console.log(err);
        }
      )
  )
}