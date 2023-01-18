import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {faHome} from "@fortawesome/free-solid-svg-icons"
import Container from "react-bootstrap/Container";
import Navbar from "react-bootstrap/Navbar";
import { Button, Col, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import { useEffect, useRef, useState } from "react";
import axios from "axios";

function Layout(props){
  const [isUserLogin, setIsUserLogin] =useState([])
  const [userName, setuserName] =useState([])

  const navigate = useNavigate();
  const email=useRef("");
  const password=useRef("");
  useEffect(()=>{
    debugger;
    const isUserLogin = JSON.parse(localStorage.getItem('isUserLogin'));
    setIsUserLogin((existingData)=>{
      return isUserLogin;
  })
  debugger
  if(localStorage.getItem('userName')!='undefined'){
  const userName = localStorage.getItem('userName');
      setuserName((existingData)=>{
        return userName;
    })
  }
  else{
    setuserName((existingData)=>{
      return "";
  })
  }
  },[])

function LogOut(){
  localStorage.clear()
  setIsUserLogin((existingData)=>{
    return false;
  })
  setuserName((existingData)=>{
    return "";
  })

  window.location.reload();
}
    function loginHandler(){
      if(email.current.value=="" || password.current.value==""){
        alert("Invalid Login")
        return;
      }
        var payload={
            Username:email.current.value,
            Password:password.current.value,
        }
        axios.post("http://sathyafernando-001-site1.gtempurl.com/api/User/Login",payload)
        .then((response)=>{
          debugger;
          localStorage.setItem("isUserLogin",response.data.validate);
          localStorage.setItem("userName",response.data.username);
          setIsUserLogin((existingData)=>{
            return response.data.validate;
          })
          setuserName((existingData)=>{
            return response.data.username;
          })            
        })
      }

    return (
        <div>
          <Navbar style={{borderBottom:"3px solid #000"}} variant="dark" expand="lg">
            <Container>
              <Col><Navbar.Brand style={{color: '#000',fontSize: '35px',fontFamily: 'cursive',fontWeight: '700'}}> <FontAwesomeIcon icon={faHome} />Funney Videos</Navbar.Brand></Col>
              {!isUserLogin?<Col>
              <form>
                <input style={{margin:'10px'}} type="email" placeholder="Email" ref={email}></input>
                <input style={{margin:'10px'}} type="password" placeholder="Password" ref={password}></input>
                <button style={{margin:'10px'}} type="button" onClick={loginHandler}>Login/Register</button>
              </form>
              </Col>:<div><Col></Col>
              <Col style={{display:'flex',flexWrap:'inherit',alignItems:'center',justifyContent:'space-between'}}>
                <p >{userName}</p>
                <div>
                <button style={{margin:'10px'}} onClick={() => navigate ("/share")}>Share a movie</button>
                <button style={{margin:'10px'}} type="button" onClick={LogOut}>Logout</button>
                </div>
              </Col></div> }
              
              
             
            </Container>
          </Navbar>
          <Container>{props.children}</Container>
        </div>
      );
}

export default Layout;