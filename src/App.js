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
    { pointerPosition: { x: 0, y: 0, z: 0.2 } },
    [
      {
        shipId: 0,
        model: "./ship.glb",
        position: new THREE.Vector3(3, 2, 0.01),
        rotation: new THREE.Euler(Math.PI / 2, 0, 0),
        scale: { x: 0.4, y: 0.4, z: 0.22 },
        isFixed: false,
      },
      {
        shipId: 1,
        model: "./ship.glb",
        position: new THREE.Vector3(4, 1, 0.01),
        rotation: new THREE.Euler(Math.PI / 2, 0, 0),
        scale: { x: 0.4, y: 0.4, z: 0.22 },
        isFixed: false,
      },
    ]
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
