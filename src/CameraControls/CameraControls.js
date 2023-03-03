import React, { useRef, useEffect, useState } from 'react';
import { useFrame } from "@react-three/fiber";
import {OrbitControls } from '@react-three/drei'
import * as THREE from 'three'

export const CameraControls = () => {
  const [state, setState] = useState({
    camera: new THREE.OrthographicCamera( window.innerWidth / - 2, window.innerWidth / 2, window.innerHeight / 2, window.innerHeight / - 2, 1, 1000 ),
    gl: new THREE.WebGLRenderer(),
  });

  const ref = useRef();
  const [polarAngle, setPolarAngle] = useState(Math.PI / 6); // initial polar angle

  useEffect(() => {
    // Add event listener for "x" button click
    window.addEventListener("keydown", handleXButtonClick);

    // Remove event listener when component unmounts
    return () => {
      window.removeEventListener("keydown", handleXButtonClick);
    };
  }, []);

  const handleXButtonClick = (event) => {
    if (event.code === "KeyX") {
      // Calculate the new polar angle
      const newPolarAngle = polarAngle === Math.PI / 6 ? Math.PI - Math.PI / 6 : Math.PI / 6;
      setPolarAngle(newPolarAngle);
    }
  };

  useFrame((state, delta) => {
    // Update the camera's polar angle
    //state.camera.position.setFromSphericalCoords(1, polarAngle, 0);
    state.camera.lookAt(0, 0, 0);

    ref.current.update();
  });

  return (
    <>
      <OrbitControls
        ref={ref}
        target={[0, 0, 0]}
        minDistance={0}
        enableRotate={true}
        enableZoom={false}
        args={[state.camera, state.gl.domElement]}
      />
    </>
  );
};
