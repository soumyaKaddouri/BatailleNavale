import React from "react";
import { Container } from "@mui/material";

const CustomContainer = (props) => {
  return (
    <Container
      maxWidth={false}
      disableGutters
      sx={{
        width: "100vw",
        height: "100vh",
        backgroundImage:
          "url('https://wowsp-wows-na.wgcdn.co/dcont/fb/image/tmb/9044adf8-aed2-11ed-a605-ac162d70f4e4_1200x.jpg')",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        backgroundSize: "100% 100%",
        backgroundRepeat: "no-repeat"
      }}
    >
      {props.children}
    </Container>
  );
};

export default CustomContainer;
