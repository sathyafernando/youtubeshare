import axios from "axios";
import { useEffect, useRef, useState } from "react";
import { Button, Card, Container, Form } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

function ShareYoutubeVideo(){
    const youtubeLink=useRef("");
    const [errorMessage, setErrorMessage] =useState([])
    const [isError, setIsError] =useState([])
    useEffect(()=>{
        setIsError((existingData)=>{
          return false;
      })
      setErrorMessage((existingData)=>{
          return "";
      })
      },[])

    const navigate=useNavigate();
    function shareYoutubeVideoHandler(){
        setIsError((existingData)=>{
            return false;
        })
        setErrorMessage((existingData)=>{
            return "";
        }) 
        var payload={
            VideoLink:youtubeLink.current.value
        }
        axios.post("https://localhost:7014/api/YoutubeVideo/ShareVideo",payload)
        .then((response)=>{
            if(!response.data.created){
                setIsError((existingData)=>{
                    return true;
                })
                setErrorMessage((existingData)=>{
                    return response.data.successMessage;
                })  
            }
            else{
            navigate("/");
            }   
        })
    }

    return <>
    <Card style={{ width: '40rem',margin:'10px' }}>
      <Card.Header className="text-center">Share a Youtube Movie</Card.Header>
      <Card.Body>
      <Container>
      <Form>
      <Form.Group className="mb-3" controlId="formYoutubeLink">
        <Form.Label>Youtube Link</Form.Label>
        <Form.Control type="text" ref={youtubeLink}/>
      </Form.Group>
      <Button variant="primary" type="button" onClick={shareYoutubeVideoHandler}>
        Submit
      </Button>
    </Form>
      </Container>
      </Card.Body>
    </Card>
    {isError?<p>{errorMessage}</p>:<p></p>}
    </>
}

export default ShareYoutubeVideo;