// import React, { useRef, useState } from "react";
// import { useFrame } from "@react-three/fiber";
//import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';

import React, { useState, useEffect, Children, useContext } from "react";
import * as THREE from "three";
import { Ship } from "../Ship/ship";
import { GLTFLoader } from "three/examples/jsm/loaders/GLTFLoader";
import { BoxItem } from "../BoxItem/boxItem";
import { GameContext } from "../GameContext/Game-context";

export const SceneManager = () => {
  const [game, setGame] = useContext(GameContext);

  const [model1, setModel1] = useState();
  const [model2, setModel2] = useState();
  const [model3, setModel3] = useState();
  const [model4, setModel4] = useState();
  const [model5, setModel5] = useState();

  const position1 = new THREE.Vector3(1, 2, 0.2);
  const position2 = new THREE.Vector3(-1, -2, 0.2);
  const position3 = new THREE.Vector3(3, 2, 0.01);
  const position4 = new THREE.Vector3(-4, 3, 0.2);
  const position5 = new THREE.Vector3(-3, -4, 0.2);

  const rotation1 = new THREE.Euler(Math.PI / 2, Math.PI / 2, 0);
  const rotation2 = new THREE.Euler(Math.PI / 2, 3*Math.PI/2, 0);
  const rotation3 = new THREE.Euler(Math.PI / 2, 0, 0);
  const rotation4 = new THREE.Euler(Math.PI / 2, Math.PI / 2, 0);

  const scale1 = { x: 0.4, y: 0.4, z: 0.2 };
  const scale2 = { x: 0.4, y: 0.4, z: 0.2 };
  const scale3 = { x: 0.4, y: 0.4, z: 0.22 };
  const scale4 = { x: 0.4, y: 0.4, z: 0.2 };

  useEffect(() => {
    new GLTFLoader().load('./ship.glb', setModel1);
    new GLTFLoader().load('./ship.glb', setModel2);
    new GLTFLoader().load('./ship.glb', setModel3);
    new GLTFLoader().load('./ship.glb', setModel4);
    new GLTFLoader().load('./ship.glb', setModel5);
    // new GLTFLoader().load("./ship.glb", setModel3);
    // new GLTFLoader().load('./ship.glb', setModel4);
  }, []);

  return (
    <>
      {/* {console.log(game.idPlayer)} */}

      {model1 && model2 ? (
        <>
          {/* <Ship position_={position1} rotation_={rotation1} scale={scale1} model={model1} /> */}
          {/* <Ship position_={position2} rotation_={rotation2} scale={scale2} model={model2} /> */}
          <Ship
            id={1}
            position_={position1}
            rotation_={rotation1}
            scale={scale1}
            model={model1}
            length={3}
            offset={1}
          />
          <Ship
            id={2}
            position_={position2}
            rotation_={rotation2}
            scale={scale2}
            model={model2}
            length={3}
            offset={1}
          />
          <Ship
            id={3}
            position_={position3}
            rotation_={rotation2}
            scale={scale2}
            model={model3}
            length={3}
            offset={1}
          />
          <Ship
            id={4}
            position_={position4}
            rotation_={rotation2}
            scale={scale2}
            model={model4}
            length={3}
            offset={1}
          />
          <Ship
            id={5}
            position_={position5}
            rotation_={rotation2}
            scale={scale2}
            model={model5}
            length={3}
            offset={1}
          />
          {/* <Ship position_={position4} rotation_={rotation4} scale={scale4} model={model4} /> */}
        </>
      ) : null}
      {Array.from({ length: 9 }, (_, i) =>
        Array.from({ length: 9 }, (_, j) => ( 
          <BoxItem BoxId={i * 10 + j - i + 1} i={i - 5} j={j + 3} key={`${i}-${j}`} isLeft={true} />
        ))
      )}

      {Array.from({ length: 9 }, (_, i) =>
        Array.from({ length: 9 }, (_, j) => (
          <BoxItem i={i + 6} j={j + 3} key={`${i}-${j}`} isLeft={false} />
        ))
      )}
    </>
  );
};
