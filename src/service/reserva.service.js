import axios from "axios";

const baseUrl = "https://localhost:7190/api"

export const postReserva = async (userid, packageid, data) => {
    const endpoint = `${baseUrl}/Reservation/?userid=${userid}&packageid=${packageid}&passengerid=1`;
    const post = JSON.stringify(data)
  
    var config = {
      method: 'post',
      url: endpoint,
      headers: {
        'Content-Type': 'application/json'
      },
      data: post
    };
  
    return axios(config)
      .then(function (response) {
        return response
      })
      .catch(function (error) {
        console.log(error);
      });
  };

  export const payment = async (data) => {
    const endpoint = `${baseUrl}/ValidationPayment`;
    const post = JSON.stringify(data)
  
    var config = {
      method: 'post',
      url: endpoint,
      headers: {
        'Content-Type': 'application/json'
      },
      data: post
    };
  
    return axios(config)
      .then(function (response) {
        console.log(response);
        return response
      })
      .catch(function (error) {
        console.log(error);
      });
  };