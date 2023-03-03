import * as THREE from 'three'
import React, { useState, useEffect, Children, useRef, Suspense, useContext } from 'react';
import { useFrame, useThree } from "@react-three/fiber";
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';
import { GameContext } from '../GameContext/Game-context';



export const Ship = ({position_, rotation_, scale, model}) => {
  const [clicked, setClicked] = useState(false);
  const [position, setPosition] = useState(position_);
  const [rotation, setRotation] = useState(rotation_);

  const [game, setGame] = useContext(GameContext);

  const { viewport } = useThree()
  // viewport = canvas in 3d units (meters)

  const ref = useRef()
  useFrame(({ mouse }) => {
    //console.log(viewport.width, viewport.height);
    if (clicked) {
      console.log(viewport);
      const _x = (mouse.x * viewport.width);
      const _y = (mouse.y * viewport.height);
      setPosition({ x: _x, y: _y, z: 0.01 });
    }
    ref.current.position.set(Math.min(Math.max(parseInt(position.x), -2), 2.5), Math.min(Math.max(parseInt(position.y), -2), 2.5), 0.01);
    ref.current.rotation.set(rotation.x, rotation.y, rotation.z);
    //console.log("position : ", position);
  })
  
    return (
      <mesh
        ref={ref}
        onPointerEnter={(event) => {
          var copy = { ...game };
          copy.hoverOverShip = true;
          setGame(copy);
        }}
        onPointerLeave={(event) => {
          var copy = { ...game };
          copy.hoverOverShip = false;
          setGame(copy);
        }}
        onClick={(e) => {
          setClicked(!clicked);
        }}
        onDoubleClick={(event) => {
          const y = ref.current.rotation.y;
          //console.log("rotation before : ", ref.current.rotation);
          
          setRotation(new THREE.Euler(ref.current.rotation.x, y+(Math.PI / 2), ref.current.rotation.z));
          //console.log("position after : ", ref.current.position);
        }}
        position={ref.current !== undefined ? ref.current.position : new THREE.Vector3(0, 0, 0.2)}
          rotation={ref.current !== undefined ? ref.current.rotation : new THREE.Euler(rotation.x, rotation.y, rotation.z)}
          scale={[scale.x, scale.y, scale.z]}
      >
          <primitive object={model.scene} />
          </mesh>
    );
}