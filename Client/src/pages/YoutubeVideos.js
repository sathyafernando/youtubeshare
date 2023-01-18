import { Container, Row } from "react-bootstrap";
import Col from "react-bootstrap/Col";
import axios from "axios";
import { useEffect, useState } from "react";

function YoutubeVideos(){
    const [youtubeVideos, setYoutubeVideos] =useState([])

    useEffect(()=>{
        axios.get("http://sathyafernando-001-site1.gtempurl.com/api/YoutubeVideo/GetVideos")
        .then((response)=>{
            setYoutubeVideos((existingData)=>{
                return response.data.youtubeVideos;
            })
        })
    },[])
 
    return <>
   
        {
            youtubeVideos.map((yv)=>(
                <Container style={{paddingTop: '10px'}}>
                <Row className="g-4">
                    <Col xs key={yv.id} >
                    <Container>
                        <div className="ratio ratio-16x9">
                            <iframe src={yv.videoLink} title={"YouTube video-"+yv.id} allowfullscreen></iframe>
                        </div>
                        </Container>
                    </Col>
                    <Col key={yv.id} >
                        <Container>
                        <h4>Movie Title</h4>
                        <p>##################</p>
                        <p>##################</p>
                        <p>#################################################################################################</p>
                        </Container>
                    </Col>
                </Row>
                </Container>
            ))
        }
   
    </>
}

export default YoutubeVideos;