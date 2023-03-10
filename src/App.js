import "./App.css";
import { Canvas } from "@react-three/fiber";
import { SceneManager } from "./SceneManager/SceneManager";
import { CameraControls } from "./CameraControls/CameraControls";
import { Box } from "@react-three/drei";
import { GameContext } from "./GameContext/Game-context";
import { useContext, useEffect, useState } from "react";
import { GameCanvas } from "./GameCanvas/Game-canvas";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import { StartingPage } from "./StartingPage/components/starting-page";
import * as THREE from "three";

function App() {
  const [game, setGame] = useState(
    {
      pointerPosition: { x: 0, y: 0, z: 0.2 },
      ships:[
      {
        shipId: 1,
        isFixed: false,
      },
      {
        shipId: 2,
        isFixed: false,
      },
      {
        shipId: 3,
        isFixed: false,
      },
      {
        shipId: 4,
        isFixed: false,
      },
      {
        shipId: 5,
        isFixed: false,
      },
    ]  
    }
  );

  return (
    <>
      <GameContext.Provider value={[game, setGame]}>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<GameCanvas />} />
            <Route path="/start" element={<StartingPage />} />
          </Routes>
        </BrowserRouter>
      </GameContext.Provider>
    </>
  );
}

export default App;
