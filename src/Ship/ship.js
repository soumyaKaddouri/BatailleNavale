import * as THREE from 'three'
import React, { useState, useEffect, Children, useRef, Suspense, useContext } from 'react';
import { useFrame, useThree } from "@react-three/fiber";
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader';
import { GameContext } from '../GameContext/Game-context';



export const Ship = ({id, position_, rotation_, scale, model, length, offset}) => {
  const [clicked, setClicked] = useState(false);
  const [position, setPosition] = useState({x:position_.x+6, y:position_.y+3, z:0.2});
  const [rotation, setRotation] = useState(rotation_);

  const [game, setGame] = useContext(GameContext);

  const ref = useRef()

  const getDirection = () => {
    var rot = (rotation.y * 180 / Math.PI) % 360;
    //console.log(rot);
    switch (rot) {
      case 0:
        return 1;
      case 90:
        return 3;
      case 180:
        return 2;
      case 270:
        return 4;
    
      default:
        break;
    }
  }

  const getAnchorPosition = () => {
    var direction = getDirection();
    console.log(position);
    var _x, _y;
    if (direction === 1 || direction === 2) {
      _x = position.x; //1: up 2: down
      if (direction === 1) {
        _y = position.y - offset;
      } else if (direction === 2) {
        _y = position.y + offset;
      }
    }
    
    else if (direction === 3 || direction === 4) {
      _y = position.y; //1: up 2: down
      if (direction === 3) {
        _x = position.x + offset;
      } else if (direction === 4) {
        _x = position.x - offset;
      }
    }
    
    return { x: _x - 6, y: _y - 3 }
  }

  useFrame(() => {
    //console.log(viewport.width, viewport.height);
    if (clicked && !(game?.ships?.find((ship) => ship.shipId === id).isFixed)) {
      //console.log(viewport);
      const _x = game.pointerPosition.x;
      const _y = game.pointerPosition.y;
      setPosition({ x: _x, y: _y, z: 0.2 });
    }
    ref.current.position.set(Math.min(Math.max(parseInt(position.x), -4 + 6 ), 4 + 6), Math.min(Math.max(parseInt(position.y), -4 + 3), 4 + 3), 0.2);
    ref.current.rotation.set(rotation.x, rotation.y, rotation.z);
    //console.log("position : ", position);
  })
  
    return (
      <mesh
        ref={ref}
        onClick={(e) => {
          if (!(game?.ships?.find((ship) => ship.shipId === id).isFixed)) {
            setClicked(!clicked);
            setGame({ ...game, clicked: clicked, currentShip: { id: id, position: getAnchorPosition(), length: length, direction: getDirection() } })
            console.log(game.currentShip);
          }
        }}
        onDoubleClick={(event) => {
          if (!(game?.ships?.find((ship) => ship.shipId === id).isFixed)) {
            const y = ref.current.rotation.y;
            setRotation(new THREE.Euler(ref.current.rotation.x, y+(Math.PI / 2), ref.current.rotation.z));
          }
          //console.log("rotation before : ", ref.current.rotation);
          
          
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