// import React, { useRef, useState } from "react";
// import { useFrame } from "@react-three/fiber";
//import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';

import React, { useState, useEffect, Children } from 'react';
import * as THREE from 'three'
import { Ship } from '../Ship/ship';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader'
import { BoxItem } from '../BoxItem/boxItem';

export const SceneManager = () => {

  const [hoverOverShip, setHoverOverShip] = useState(false); 

  const [model1, setModel1] = useState();
  const [model2, setModel2] = useState();
  const [model3, setModel3] = useState();
  const [model4, setModel4] = useState();

  const range = (start, stop, step) =>
    Array.from({ length: (stop - start) / step + 1 }, (_, i) => start + i * step);
  
  

  const position1 = new THREE.Vector3(1, 2, 0.2);
  const position2 = new THREE.Vector3(-1, -2, 0.2);
  const position3 = new THREE.Vector3(3*0.5, 2*0.5, 0.01);
  const position4 = new THREE.Vector3(-3, -3, 0.2);

  const rotation1 = new THREE.Euler(Math.PI / 2, Math.PI / 2, 0);
  const rotation2 = new THREE.Euler(Math.PI / 2, 0, 0);
  const rotation3 = new THREE.Euler(Math.PI / 2, 0, 0);
  const rotation4 = new THREE.Euler(Math.PI / 2, Math.PI / 2, 0);

  const scale1 = { x: 0.001, y: 0.001, z: 0.001 };
  const scale2 = { x: 0.04, y: 0.04, z: 0.03 };
  const scale3 = { x: 0.4*0.5, y: 0.4*0.5, z: 0.22*0.5 };
  const scale4 = { x: 0.4, y: 0.4, z: 0.2 };

  useEffect(() => {
    // new GLTFLoader().load('./scene.gltf', setModel1);
    // new GLTFLoader().load('./ship2.glb', setModel2);
    new GLTFLoader().load('./ship.glb', setModel3);
    // new GLTFLoader().load('./ship.glb', setModel4);
  }, []);

  return (
    <>
      {model3 ? (
        <>
          {/* <Ship position_={position1} rotation_={rotation1} scale={scale1} model={model1} /> */}
          {/* <Ship position_={position2} rotation_={rotation2} scale={scale2} model={model2} /> */}
          <Ship position_={position3} rotation_={rotation3} scale={scale3} model={model3} />
          {/* <Ship position_={position4} rotation_={rotation4} scale={scale4} model={model4} /> */}
        </>
      ) : null}
      {Array.from({ length: 4.5/0.5 + 1 }, (_, i) =>
        Array.from({ length: 4.5/0.5 + 1}, (_, j) => (
          <BoxItem i={i*0.5} j={j*0.5} key={`${i*0.5}-${j*0.5}`}/>
        ))
      )}
    </>
  );
};
