import { Canvas } from "@react-three/fiber";
import { CameraControls } from "../CameraControls/CameraControls";
import { SceneManager } from "../SceneManager/SceneManager";
import { Alert, Button, Card, Collapse, Grid, IconButton, TextField, Typography } from "@mui/material";
import styled from "@emotion/styled";
import { purple } from "@mui/material/colors";
import { useContext, useEffect, useState } from "react";
import { GameContext } from "../GameContext/Game-context";
import CloseIcon from '@mui/icons-material/Close';
import { Navigate } from "react-router-dom";




export const GameCanvas = () => {

  const [game, setGame] = useContext(GameContext);

  const [gameState, setGameState] = useState(1);

  const [isYourTurn, setIsYourTurn] = useState(false);

  const [isShootClicked, setIsShootClicked] = useState(false);

  const [ValidateShipPositionButtonCounter, setValidateShipPositionButtonCounter] = useState(0);

  const [showValidateShipPositionButton, setShowValidateShipPositionButton] = useState(!game?.clicked);

  const [cannotAddShipErr, setCannotAddShipErr] = useState(false);

  const [gameStarted, setGameStarted] = useState();

  useEffect(
    () => {
      setShowValidateShipPositionButton(!game?.clicked);
    },
    [game?.clicked]
  );

  
 
  const handleValidateShipPosition = () => {


    fetch("https://192.168.43.54:5028/GameMaps/"+game.idPlayer+"/Add_Ship?x="+game.currentShip.position.x+"&y="+game.currentShip.position.y+"&direction="+game.currentShip.direction+"&longueur="+game.currentShip.length, {
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
    }).then(response => {
    if (response.ok) {
      return response.json();
    } else {
      return response.text().then(response => {throw new Error(response)})
    }
  })
      .then(data => {
        console.log(data);

        //game?.ships?.find((ship) => ship.shipId === game?.currentShip?.id).isFixed = true;
        var copy = game;
        copy.ships.forEach(ship => {
          if (ship.shipId === game?.currentShip?.id) {
            ship.isFixed = true;

        }
    });

    setGame(copy);

    setValidateShipPositionButtonCounter(ValidateShipPositionButtonCounter + 1);

  })
  .catch(error => {
    //console.log(error.message);
    setCannotAddShipErr(error.message);

  });

    setShowValidateShipPositionButton(!showValidateShipPositionButton);
  }

  const playerIsReady = () => {
    fetch("https://192.168.43.54:5028/Players/"+game.idPlayer+"/Is_Ready", {
    "credentials": "omit",
    "headers": {
        "Accept": "*/*",
        "Accept-Language": "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3",
        "Sec-Fetch-Dest": "empty",
        "Sec-Fetch-Mode": "cors",
        "Sec-Fetch-Site": "same-origin"
    },
    "method": "PUT",
    "mode": "cors"
    }).then((res) => { return res.text() })
      .then(async (data) =>
      {
        console.log(data);
        console.log("Session ID : ", game.idSession);
        var areTwoPlayersReady = false;
        while (!areTwoPlayersReady) {
          fetch("https://192.168.43.54:5028/Sessions/"+game.idSession, {
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
            if (data.players[0].etat_joueur + data.players[1].etat_joueur === 2) {
              areTwoPlayersReady = true;
              fetch("https://192.168.43.54:5028/Sessions/"+game.idSession+"/ChangeGameState", {
              "credentials": "omit",
              "headers": {
                  "Accept": "*/*",
                  "Accept-Language": "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3",
                  "Sec-Fetch-Dest": "empty",
                  "Sec-Fetch-Mode": "cors",
                  "Sec-Fetch-Site": "same-origin"
              },
              "method": "PUT",
              "mode": "cors"
              }).then((res) => { return res.text() })
                .then(data => {
                  console.log(data);
                  setGameStarted(true);
                });
            }
          });
          await new Promise(r => setTimeout(r, 3000));
        }
      }
      
    );
  }

  const handleShoot = () => {
    if (game.isBoxClicked === true) {
      fetch("https://192.168.43.54:5028/Players/" + game.idPlayer + "/Shoot?x=" + game.clickedBox.x + "&y=" + game.clickedBox.y, {
        "credentials": "omit",
        "headers": {
          "Accept": "*/*",
          "Accept-Language": "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3",
          "Sec-Fetch-Dest": "empty",
          "Sec-Fetch-Mode": "cors",
          "Sec-Fetch-Site": "same-origin"
        },
        "method": "PUT",
        "mode": "cors"
      }).then(response => {
    if (response.ok) {
      return response.json();
    } else {
      return response.text().then(response => {throw new Error(response)})
    }
  })
        // eslint-disable-next-line no-loop-func
        .then(data => {
          console.log(data.value.resultat);
          if (data.value.resultat === -1) {
            //texture
            var copy1 = { ...game };
            copy1.leftBoxes[copy1.clickedBox.id - 1].type = 1;
            setGame(copy1);
          } else if (data.value.resultat === 1) {
            //explosion
            var copy2 = { ...game };
            copy2.leftBoxes[copy2.clickedBox.id - 1].type = 2;
            setGame(copy2);
          }
        }
        ).catch(error => {
          console.log(error.message);
          setIsYourTurn(false);
          setGame({...game, exploded:false})
  });
    }
    setGame({ ...game, isBoxClicked: false});
  }


  
  const ValidateShipPositionButton = styled(Button)(() => ({
    marginBottom: "10%",
  backgroundColor: "#00ffe0",
  '&:hover': {
    backgroundColor: "#00ff00",
  },
  }));
  
  const ReadyButton = styled(Button)(() => ({
    marginBottom: "10%",
    backgroundColor: "#cff1e5",
  '&:hover': {
    backgroundColor: "#00ff00",
  },
}));

  return (
      <div style={{display: "flex", flexFlow: "row"}}>
      <Canvas style={{ width: '1366px', height: '720px', backgroundImage: '#ffffff' }}>
          <pointLight position={[0, 0, 4]} />
          <SceneManager />
          <CameraControls />
        </Canvas>
      <div style={{ display: "flex", flexFlow: "column", justifyContent: "center" , maxWidth: "10%"}}>
        {!gameStarted ? <>
          <ValidateShipPositionButton onClick={handleValidateShipPosition} disabled={showValidateShipPositionButton}>Validate position</ValidateShipPositionButton>
        <ReadyButton disabled={!(ValidateShipPositionButtonCounter === 5)} onClick={playerIsReady}>Ready</ReadyButton>
        {cannotAddShipErr &&
          <Collapse in={cannotAddShipErr !== null}>
            <Alert
              severity="error"
          action={
            <IconButton
              aria-label="close"
              color="inherit"
              size="small"
              onClick={() => {
                setCannotAddShipErr(null);
              }}
            >
              <CloseIcon fontSize="inherit" />
            </IconButton>
          }
          sx={{ mb: 2 }}
        >
          {cannotAddShipErr}
        </Alert>
      </Collapse>
        
          }</>
          : <>
            <Collapse in={!isYourTurn}>
            <Alert
              severity="error"
          action={
            <IconButton
              aria-label="close"
              color="inherit"
              size="small"
              onClick={() => {
                setIsYourTurn(!isYourTurn);
              }}
            >
              <CloseIcon fontSize="inherit" />
            </IconButton>
          }
          sx={{ mb: 2 }}
        >
          It's not your turn !
        </Alert>
      </Collapse>
            <ReadyButton disabled={!game.isBoxClicked && !isYourTurn} onClick={handleShoot}>Shoot</ReadyButton>
          </>
        }
        

        </div>
      </div>
    );
}