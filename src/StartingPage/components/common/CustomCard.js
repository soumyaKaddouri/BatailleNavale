import React, { useRef, useState } from "react";
import { Button, Card, Grid, TextField, Typography } from "@mui/material";
import styled from "@emotion/styled";
import { purple } from "@mui/material/colors";

import {
  MDBBtn,
  MDBModal,
  MDBModalDialog,
  MDBModalContent,
  MDBModalHeader,
  MDBModalTitle,
  MDBModalBody,
  MDBModalFooter,
} from 'mdb-react-ui-kit';
import { redirect } from "react-router-dom";

const CustomCard = (props) => {

  const [sessionId, setSessionId] = useState(null);
  const [player, setPlayer] = useState(null);
  const [playerNameEntered, setPlayerNameEntered] = useState(false);
  const [maxPlayersAchieved, setMaxPlayersAchieved] = useState(false);
  const [maxPlayersAchievedErr, setMaxPlayersAchievedErr] = useState(null);

  const handleCreateSession = async (e) => {
    var res = await fetch("https://localhost:5028/NouvellePartie", {
    "credentials": "omit",
    "headers": {
      "Accept": "*/*",
      "Accept-Language": "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3",
      "Sec-Fetch-Dest": "empty",
      "Sec-Fetch-Mode": "cors",
      "Sec-Fetch-Site": "same-origin"
    },
    "method": "GET",
    "mode": "cors"
  })
  .then(response => response.json())
      .then(data => {
        setSessionId(data);
      });
  }

  const handlePlayerName = (e) => {
    setPlayerNameEntered(true);
    fetch("https://localhost:5028/Sessions/" + sessionId + "/RejoindreUneSession?playername=" + player.name, {
    "credentials": "omit",
    "headers": {
      "Accept": "*/*",
      "Accept-Language": "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3",
      "Sec-Fetch-Dest": "empty",
      "Sec-Fetch-Mode": "cors",
      "Sec-Fetch-Site": "same-origin"
    },
    "method": "POST",
    "mode": "cors"
  })
  .then(response => {
    if (response.ok) {
      return response.json();
    } else {
      return response.text().then(response => {throw new Error(response)})
    }
  })
  .then(data => {
    setPlayer({ ...player, id: data });
  })
  .catch(error => {
    console.log(error.message);
    setMaxPlayersAchievedErr(error.message)
    setMaxPlayersAchieved(true);
  });


  }
  
  const ColorButton = styled(Button)(() => ({
  color: purple[1000],
  backgroundColor: "#233c52",
  '&:hover': {
    backgroundColor: "#6080a3",
  },
}));

  return (
    <>
    <Card
      style={{
        width: "30%",
        height: "40%",
        background: "rgba(255, 255, 255, 0.5)",
        border: "2px solid rgba(0, 0, 0, 0.3)",
        borderRadius: "25px",
        display: "flex",
        padding: "15px",
        //alignItems: "center",
        boxShadow: "4px 5px 34px rgba(0, 0, 0, 0.25)",
        flexDirection: "column",
      }}
      ><Grid container spacing={4} direction="column" justifyContent="center" alignItems="center">
          {!maxPlayersAchieved && !playerNameEntered && <>
        <Grid item xs={1}>
        <Typography variant="h4" component="h2" style={{marginTop: "10%", fontWeight: "bold", color: "#485666", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>Welcome Admiral</Typography>
        </Grid>
        {!sessionId && <>
          <Grid item xs={2}>
          <ColorButton variant="contained" onClick={handleCreateSession}>Create session</ColorButton>
          </Grid>
          <Grid item xs={3}>
          <Button variant="outlined">Join session</Button>
          </Grid> 
        </>}
        {sessionId && <>
          <Grid item xs={3}>
          <TextField id="playerName" placeholder="playerName" label="User name" variant="outlined" onChange={(event) => {setPlayer({name:event.target.value})}}/>
          </Grid> 
          <Grid item xs={2}>
          <ColorButton variant="contained" onClick={(e) => {handlePlayerName(e)}}>Start</ColorButton>
          </Grid>
            </>}
          </>}

          {playerNameEntered && <>
            <Grid item xs={1}></Grid>
            <Grid item xs={2}></Grid>
            <Grid item xs={3}>
              <Typography variant="h6" component="h6" style={{marginTop: "10%", fontWeight: "bold", color: "#00ff00", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>Waiting for another player to join the session...</Typography>
            </Grid>
          </>}
          
          
          {maxPlayersAchieved && <>
          <Grid item xs={1}></Grid>
          <Grid item xs={2}>
            <Typography variant="h4" component="h2" style={{marginTop: "10%", fontWeight: "bold", color: "#ff0000", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>{maxPlayersAchievedErr}</Typography>
          </Grid>
          <Grid item xs={3}>
            <ColorButton variant="contained" onClick={(e) => {}}>Back</ColorButton>
          </Grid>
          </>}
      </Grid>
      {props.children}
      </Card>
    </>
  );
};

export default CustomCard;
