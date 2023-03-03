import { Box } from "@react-three/drei";
import { useLoader } from "@react-three/fiber";
import { useContext, useEffect, useRef, useState } from "react";
import * as THREE from 'three'
import { TextureLoader } from "three";
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader'
import { GameContext } from "../GameContext/Game-context";

export const BoxItem = ({i, j}) => {
    const [colorCases, setColorCases] = useState(0x3ac9fc);
    const [texture, setTexture] = useState(null);
    const [exploded, setExploded] = useState(false);
    const [destroyed, setDestroyed] = useState(false);
    const [explosionTexture, setExplosionTexture] = useState();
    const [destructionTexture, setDestructionTexture] = useState();

    const [game, setGame] = useContext(GameContext);
    
    const meshRef = useRef();
    const newTexture = new THREE.TextureLoader().load("red-x.png");
    //const explosionTexture = new THREE.GLTFLoader().load("timeframe_explosion.glb");

    useEffect(() => {
    new GLTFLoader().load('./Fireball.glb', setExplosionTexture);
    // new GLTFLoader().load('./dirty_stones_pile.glb', setDestructionTexture);
  }, []);

    return (
        <Box
            ref={meshRef}
            onPointerEnter={(event) => { (!game.hoverOverShip && setColorCases(0xfc1c49)) }}
            onPointerLeave={(event) => { setColorCases(0x3ac9fc) }}
            onClick={() => {
                // Change the texture when the box is clicked
                (!game.hoverOverShip && setTexture(newTexture));
                //setExploded(true);
                //setDestroyed(true);
            }}
            position={new THREE.Vector3(i - 2, j - 2, 0)}
            key={`${i}-${j}`}>
            <boxGeometry
              args={[0.42, 0.42, 0.05]}>
            </boxGeometry>
            <meshBasicMaterial color={colorCases}/>
            {texture && <meshBasicMaterial attach="material" map={texture} />}
            {exploded === true &&
                <mesh
                    scale={[0.9, 0.9, 0.9]}
                >
                <primitive object={explosionTexture.scene} />
            </mesh>}
            {destroyed === true &&
                <mesh
                    scale={[0.1, 0.2, 0.2]}
                >
                <primitive object={destructionTexture.scene} />
            </mesh>}
          </Box >
    );
}