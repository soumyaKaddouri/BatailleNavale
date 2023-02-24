import './App.css';
import { Canvas } from "@react-three/fiber";
import { SceneManager } from './SceneManager/SceneManager';
import { CameraControls } from './CameraControls/CameraControls';
import { Box } from '@react-three/drei';

function App() {
  return (
    <>
      <Canvas>
        <SceneManager />
        <CameraControls />
      </Canvas>
    </>
  );
}

export default App;
