import React, { useContext, useEffect, useState } from "react";
import { Button, Card, Grid, TextField, Typography } from "@mui/material";
import styled from "@emotion/styled";
import { purple } from "@mui/material/colors";
import { api } from "../../../api";
import { useNavigate } from "react-router-dom";
import { GameContext } from "../../../GameContext/Game-context";

const CustomCard = (props) => {

  const [game, setGame] = useContext(GameContext);

  const [sessionId, setSessionId] = useState(null);
  const [player, setPlayer] = useState(null);
  const [playerNameEntered, setPlayerNameEntered] = useState(false);
  const [maxPlayersAchieved, setMaxPlayersAchieved] = useState(false);
  const [maxPlayersAchievedErr, setMaxPlayersAchievedErr] = useState(null);
  const [createSessionSelected, setCreateSessionSelected] = useState(true);


  const navigate = useNavigate();

  const handleCreateSession = async (e) => {
    var res = await fetch("https://"+api+":5028/NouvellePartie", {
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
        setGame({ ...game, idSession: data});
      });
  }

  const handlePlayerName1 = (e) => {
    setPlayerNameEntered(true);
    fetch("https://"+api+":5028/Sessions/" + sessionId + "/RejoindreUneSession?playername=" + player.name, {
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
      .then(async data => {
    setGame({ ...game, idPlayer: data });
    setPlayer({ ...player, id: data });
    var areTwoPlayersLoged = false;
    while (!areTwoPlayersLoged) {
      fetch("https://192.168.43.54:5028/Sessions/"+sessionId, {
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
    }).then((response) => { return response.json(); })
      // eslint-disable-next-line no-loop-func
      .then((data) => {
        //console.log(data.players.length);
        if (data.players.length === 2) {
          navigate("/");
          areTwoPlayersLoged = true;
        }
      });
      await new Promise(r => setTimeout(r, 3000));
    }
  })
  .catch(error => {
    console.log(error.message);
    setMaxPlayersAchievedErr(error.message)
    setMaxPlayersAchieved(true);
  });


  }

  const handlePlayerName2 = (e) => {
    setPlayerNameEntered(true);
    fetch("https://"+api+":5028/Sessions/" + sessionId + "/RejoindreUneSession?playername=" + player.name, {
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
        //console.log(data);
        setGame({ ...game, idPlayer: data });
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
          {createSessionSelected && <>{!maxPlayersAchieved && !playerNameEntered && <>
        <Grid item xs={1}>
        <Typography variant="h4" component="h2" style={{marginTop: "10%", fontWeight: "bold", color: "#485666", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>Welcome Admiral</Typography>
        </Grid>
        {!sessionId && <>
          <Grid item xs={2}>
          <ColorButton variant="contained" onClick={handleCreateSession}>Create session</ColorButton>
          </Grid>
          <Grid item xs={3}>
                <Button variant="outlined" onClick={(e) => { setCreateSessionSelected(false); }}>Join session</Button>
          </Grid> 
        </>}
        {sessionId && <>
          <Grid item xs={3}>
          <TextField id="playerName" placeholder="playerName" label="User name" variant="outlined" onChange={(event) => {setPlayer({name:event.target.value})}}/>
          </Grid> 
          <Grid item xs={2}>
                <ColorButton variant="contained" onClick={(e) => {
                  handlePlayerName1(e);
                }}>Start</ColorButton>
          </Grid>
            </>}
          </>}

          {playerNameEntered && <>
            <Grid item xs={1}></Grid>
            <Grid item xs={2}>
              <Typography variant="h6" component="h6" style={{ marginTop: "10%", fontWeight: "bold", color: "#000000", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080" }}>Session id : {sessionId}</Typography>
            </Grid>
            <Grid item xs={3}>
              <Typography variant="h6" component="h6" style={{marginTop: "10%", fontWeight: "bold", color: "#00ff00", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>Waiting for another player to join the session...</Typography>
            </Grid>
          </>}
        
          </>}
          {!createSessionSelected && !maxPlayersAchieved &&<>
          <Grid item xs={1}>
              <TextField id="SessionID" placeholder="Session ID" label="Session ID" variant="outlined" onChange={(event) => {
                setSessionId(event.target.value);
              setGame({ ...game, idSession: event.target.value});
              }} />
            </Grid>
            <Grid item xs={2}>
          <TextField id="playerName" placeholder="Player Name" label="Player name" variant="outlined" onChange={(event) => {setPlayer({name:event.target.value})}}/>
          </Grid>
          <Grid item xs={3}>
              <ColorButton variant="contained" onClick={(e) => {
                handlePlayerName2(e);
                navigate("/");
              }}>Start</ColorButton>
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
