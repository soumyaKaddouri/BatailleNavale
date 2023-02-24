import React, { useRef, useEffect, useState } from 'react';
import { useFrame } from "@react-three/fiber";
import {OrbitControls } from '@react-three/drei'
import * as THREE from 'three'

export const CameraControls = () => {
  const [camera, setCamera] = useState();

  document.addEventListener('mousedown', onDocumentMouseDown, false);
  document.addEventListener('mouseup', onDocumentMouseUp, false);
  document.addEventListener('mousemove', onDocumentMouseMove, false);
  document.addEventListener('keydown', onDocumentKeyDown, false);



  let isUserInteracting = false;
  let onPointerDownPointerX, onPointerDownPointerY;

  const [lat, setLat] = useState(0);
  const [lon, setLon] = useState(0);

function onDocumentMouseDown(event) {
    isUserInteracting = true;
    onPointerDownPointerX = event.clientX;
    onPointerDownPointerY = event.clientY;
}

function onDocumentMouseUp(event) {
    isUserInteracting = false;
    mouseClicked = false;
}

function onDocumentMouseMove(event) {
    if (isUserInteracting === true) {
        setLon((onPointerDownPointerX - event.clientX) * 0.0001 + lon);
        setLat((event.clientY - onPointerDownPointerY) * 0.0001 + lat);
    }
}

function onDocumentKeyDown(event) {
    if (event.code === 'KeyX') {
        // zoom out
        camera.position.z += 2;
    } else if (event.code === 'KeyZ') {
        // zoom in
        camera.position.z -= 2;
    }
}


  const [state, setState] = useState({
    camera: new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 1, 1000),
    gl: new THREE.WebGLRenderer(),
  });

  useEffect(
    () => {
      var copy = { ...state };
      copy.gl.setSize(window.innerWidth, window.innerHeight);
      setState(copy);
      setCamera(copy.camera);
    },
    []
  );
  const ref = useRef();
  const [mouseClicked, setMouseclicked] = useState(false);

  useFrame((state, delta) => {
    ref.current.update();
    if (mouseClicked) {
      var copy = { ...state };
      copy.camera = camera;
      setState(copy);
      ref.current.camera.position.z = 20 * Math.sin(lat);
      ref.current.camera.lookAt(0, 0, 0);
    }
  });


  return (
    <>
      <OrbitControls ref={ref} args={[state.camera, state.gl.domElement]} />
      <mesh onClick={() => setMouseclicked({ mouseClicked: true })} />
    </>
  );
};