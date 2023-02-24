// import React, { useRef, useState } from "react";
// import { useFrame } from "@react-three/fiber";
//import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';

import React, { useState, useEffect, Children } from 'react';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';
import * as THREE from 'three'
import { Box } from '@react-three/drei';




export const SceneManager = () => {
  const [model, setModel] = useState();
  const [model2, setModel2] = useState();
  const [model3, setModel3] = useState();
  useEffect(() => {
    new GLTFLoader().load('./ship.glb', setModel);
    new GLTFLoader().load('./ship.glb', setModel2);
    new GLTFLoader().load('./ship.glb', setModel3);
  }, []);

  return (
    <>
      {model ? (
        <>
        <mesh
          visible
          position={new THREE.Vector3(-2, 1, 0.2)}
          rotation={new THREE.Euler(Math.PI / 2, 0, 0)}
          scale={[0.4, 0.4, 0.2]}
        >
          <primitive object={model.scene} />
          </mesh>
        <mesh
          visible
          position={new THREE.Vector3(3, 0, 0.2)}
          rotation={new THREE.Euler(Math.PI / 2, 0, 0)}
          scale={[0.4, 0.4, 0.3]}
        >
          <primitive object={model2.scene} />
        </mesh>
        <mesh
          visible
          position={new THREE.Vector3(-1, -2, 0.2)}
          rotation={new THREE.Euler(Math.PI / 2, 0, 0)}
          scale={[0.4, 0.4, 0.2]}
        >
          <primitive object={model3.scene} />
        </mesh>
        </>
      ) : null}
      {Array.from({ length: 9 }, (_, i) =>
        Array.from({ length: 9 }, (_, j) => (
          <Box position={[(i - 4), (j - 4), 0 ]} key={`${i}-${j}`}>
            <boxGeometry
                args={[0.85, 0.85, 0.1]}>
              </boxGeometry>
              <meshBasicMaterial color={0x3ac9fc} />            
          </Box >
        ))
      )}
    </>
  );
};
