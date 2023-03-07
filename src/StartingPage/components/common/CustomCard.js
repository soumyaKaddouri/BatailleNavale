import React from "react";
import { Button, Card, Grid, Typography } from "@mui/material";
import styled from "@emotion/styled";
import { purple } from "@mui/material/colors";

const CustomCard = (props) => {

  const handleCreateSession = async (e) => {
    var response = await fetch("http://localhost:5028/NouvellePartie", {
    "method": "GET",
    "mode": "cors"
});
    
  }
  
  const ColorButton = styled(Button)(() => ({
  color: purple[1000],
  backgroundColor: "#233c52",
  '&:hover': {
    backgroundColor: "#6080a3",
  },
}));

  return (
    <Card
      style={{
        width: "30%",
        height: "40%",
        background: "rgba(255, 255, 255, 0.5)",
        border: "2px solid rgba(0, 0, 0, 0.3)",
        borderRadius: "25px",
        display: "flex",
        padding: "15px",
        //alignItems: "center",
        boxShadow: "4px 5px 34px rgba(0, 0, 0, 0.25)",
        flexDirection: "column",
      }}
    ><Grid container spacing={4} direction="column" justifyContent="center" alignItems="center">
        <Grid item xs={1}>
        <Typography variant="h4" component="h2" style={{marginTop: "10%", fontWeight: "bold", color: "#485666", textAlign: "center", textShadow: "0 0 4px #466080, 0 0 5px #466080"}}>Welcome Navy Soldier</Typography>
        </Grid>
        <Grid item xs={2}>
        <ColorButton variant="contained" onClick={handleCreateSession}>Create session</ColorButton>
        </Grid>
        <Grid item xs={3}>
        <Button variant="outlined">Join session</Button>
        </Grid> 
      </Grid>
      {props.children}
    </Card>
  );
};

export default CustomCard;
