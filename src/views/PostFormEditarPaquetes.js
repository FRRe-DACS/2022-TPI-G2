import React, { useState } from 'react'
import Axios from 'axios'
import './PostForm.css';

function PostFormEditarPaquetes() {
    var url = "https://localhost:7190/api/Package/"
    const [data, setData] = useState({
        id: "",
        name: "",
        description: "",
        packagePrice: "",
        serviceId: "",
        validDate: ""

    })

    function submit(e){
        e.preventDefault();
        Axios.put(url+data.id,{
            id: parseInt(data.id),
            name: data.name,
            description: data.description,
            packagePrice: parseFloat(data.packagePrice),
            serviceId: parseInt(data.serviceId),
            validDate: (data.validDate),
            
        })
            .then(res=>{
                console.log(res.data)
            })
    }
    
    function handle(e){
        const newdata={...data}
        newdata[e.target.id] = e.target.value
        
        setData(newdata)
        console.log(newdata)
    }

    return (
        <div className='formulario'>
            <form onSubmit={(e)=> submit(e)}>
                <ol>
                    <ul><input onChange={(e)=>handle(e)} id="id" value={data.ide}placeholder="id" type="number"></input></ul>
                    <br/>
                    <ul><input onChange={(e)=>handle(e)} id="name" value={data.name} placeholder="name" type="text"></input></ul>
                    <br/>
                    <ul><input onChange={(e)=>handle(e)} id="description" value={data.description} placeholder="description" type="text"></input></ul>
                    <br/>
                    <ul><input onChange={(e)=>handle(e)} id="packagePrice" value={data.packagePrice} placeholder="packagePrice" type="number"></input></ul>
                    <br/>
                    <ul><input onChange={(e)=>handle(e)} id="serviceId" value={data.serviceId} placeholder="serviceId" type="number"></input></ul>
                    <br/>
                    <ul><input onChange={(e)=>handle(e)} id="validDate" value={data.validDate} placeholder="validDate" type="date"></input></ul>
                    <br/>
                    <ul><button>Submit</button></ul>
                </ol>
                
                
                
                
            </form>
        </div>
    )
}




export default PostFormEditarPaquetes;