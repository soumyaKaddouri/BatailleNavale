import { Box } from "@react-three/drei";
import { useLoader } from "@react-three/fiber";
import { useContext, useEffect, useRef, useState } from "react";
import * as THREE from 'three'
import { TextureLoader } from "three";
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader'
import { GameContext } from "../GameContext/Game-context";

export const BoxItem = ({i, j, isLeft}) => {
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
            onPointerEnter={(event) => {
                (isLeft  && setColorCases(0xfc1c49));
                var copy = { ...game , pointerPosition: { x: i - 4, y: j - 4, z: 0.2 }};
                //copy.pointerPosition = { x: i - 4, y: j - 4, z: 0.2 };
                setGame(copy);
                //console.log(game.pointerPosition);
            }}
            onPointerLeave={(event) => { setColorCases(0x3ac9fc) }}
            onClick={() => {
                // Change the texture when the box is clicked
                (!game?.isBoxClicked && setTexture(newTexture));
                (isLeft && setGame({ ...game, clickedBox: { x:i+5, y:j-3}, isBoxClicked: true}));
                //setExploded(true);
                //setDestroyed(true);
            }}
            position={new THREE.Vector3(i - 4, j - 4, 0)}
            key={`${i}-${j}`}>
            <boxGeometry
              args={[0.82, 0.82, 0.1]}>
            </boxGeometry>
            <meshBasicMaterial color={colorCases}/>
            {isLeft && texture && <meshBasicMaterial attach="material" map={texture} />}
            {exploded === true &&
                <mesh
                    scale={[0.9, 0.9, 0.9]}
                >
                <primitive object={explosionTexture.scene} />
            </mesh>}
          </Box >
    );
}