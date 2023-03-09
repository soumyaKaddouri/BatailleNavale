import { Canvas } from "@react-three/fiber";
import { CameraControls } from "../CameraControls/CameraControls";
import { SceneManager } from "../SceneManager/SceneManager";
import { Button, Card, Grid, TextField, Typography } from "@mui/material";
import styled from "@emotion/styled";
import { purple } from "@mui/material/colors";
import { useContext, useEffect, useState } from "react";
import { GameContext } from "../GameContext/Game-context";




export const GameCanvas = () => {

  const [game, setGame] = useContext(GameContext);
  const [ValidateShipPositionButtonCounter, setValidateShipPositionButtonCounter] = useState(0);

  const [showValidateShipPositionButton, setShowValidateShipPositionButton] = useState(!game?.clicked);

  useEffect(
    () => {
      setShowValidateShipPositionButton(!game?.clicked);
    },
    [game?.clicked]
  );

  const handleValidateShipPosition = () => {
    setValidateShipPositionButtonCounter(ValidateShipPositionButtonCounter + 1);
    setShowValidateShipPositionButton(!showValidateShipPositionButton);

  }

  
  const ValidateShipPositionButton = styled(Button)(() => ({
    marginBottom: "10%",
  backgroundColor: "#00ffe0",
  '&:hover': {
    backgroundColor: "#00ff00",
  },
  }));
  
  const ReadyButton = styled(Button)(() => ({
    backgroundColor: "#cff1e5",
  '&:hover': {
    backgroundColor: "#00ff00",
  },
}));

  return (
      <div style={{display: "flex", flexFlow: "row"}}>
        <Canvas style={{ width: '1366px', height: '720px' }}>
          <pointLight position={[0, 0, 4]} />
          <SceneManager />
          <CameraControls />
        </Canvas>
      <div style={{ display: "flex", flexFlow: "column", justifyContent: "center" }}>
        <ValidateShipPositionButton onClick={handleValidateShipPosition} disabled={showValidateShipPositionButton}>Validate position</ValidateShipPositionButton>
        <ReadyButton disabled={!(ValidateShipPositionButtonCounter === 5)}>Ready</ReadyButton>
        </div>
      </div>
    );
}