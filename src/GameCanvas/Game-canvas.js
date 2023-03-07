import { Canvas } from "@react-three/fiber";
import { CameraControls } from "../CameraControls/CameraControls";
import { SceneManager } from "../SceneManager/SceneManager";


export const GameCanvas = () => {
    return (
        <Canvas style={{ width: '1366px', height: '720px' }}>
          <pointLight position={[0, 0, 4]} />
          <SceneManager />
          <CameraControls />
        </Canvas>
    );
}