import './App.css';
import { Canvas } from "@react-three/fiber";
import { SceneManager } from './SceneManager/SceneManager';
import { CameraControls } from './CameraControls/CameraControls';
import { Box } from '@react-three/drei';
import { GameContext } from './GameContext/Game-context';
import { useContext, useEffect, useState } from 'react';

function App() {
  const [game, setGame] = useState({hoverOverShip:false});

  return (
    <>
      <GameContext.Provider value={[game, setGame]}>
      <Canvas>
        <pointLight position={[0, 0, 4]} />
        <SceneManager />
        <CameraControls />
        </Canvas>
      </GameContext.Provider>
    </>
  );
}

export default App;
